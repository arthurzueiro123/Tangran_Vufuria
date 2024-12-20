// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Load_pieces_mmulti : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class LoadManager_multi : MonoBehaviour
{
    [Tooltip("Lista de objetos que possuem o script DragAndSave")]
    public List<GameObject> objectsToLoad;

    [Tooltip("Nome da pasta dentro de Resources")]
    public string resourcesFolder = "Tangram";

    public string sceneName;

    private TextAsset[] jsonFiles; // Lista de arquivos JSON na pasta Resources/Tangram
    private int currentFileIndex = 0; // Índice do arquivo JSON atual

    private float player1Timer = 300f; // Timer regressivo para o Player 1 (5 minutos)
    private float player2Timer = 300f; // Timer regressivo para o Player 2 (5 minutos)
    private bool isPlayer1Turn = true; // Indica se é a vez do Player 1

    private int player1Points = 0;
    private int player2Points = 0;

    [Tooltip("Referência para o TextMeshPro que exibe o nome do jogador e o timer")]
    public TextMeshProUGUI playerInfoText;

    private void Start()
    {
        // Carrega todos os arquivos JSON da pasta Resources/Tangram
        jsonFiles = Resources.LoadAll<TextAsset>(resourcesFolder);

        if (jsonFiles.Length == 0)
        {
            Debug.LogError("Nenhum arquivo JSON encontrado na pasta Resources/Tangram!");
            return;
        }

        Debug.Log($"Total de arquivos JSON carregados: {jsonFiles.Length}");

        // Carrega o primeiro arquivo JSON
        SwitchPlayer();
        LoadAllObjects();
    }

    private void Update()
    {
        // Atualiza o timer do jogador atual
        if (isPlayer1Turn)
        {
            player1Timer -= Time.deltaTime;
            if (player1Timer <= 0)
            {
                player1Timer = 0;
                SwitchPlayer();
            }
        }
        else
        {
            player2Timer -= Time.deltaTime;
            if (player2Timer <= 0)
            {
                player2Timer = 0;
                SwitchPlayer();
            }
        }

        // Atualiza o TextMeshPro com o nome do jogador e o timer atual
        UpdatePlayerInfoText();
    }

    private void UpdatePlayerInfoText()
    {
        string currentPlayerName = isPlayer1Turn ? PlayerPrefs.GetString("CurrentPlayer1Name_multi", "Player 1") : PlayerPrefs.GetString("CurrentPlayer2Name_multi", "Player 2");
        float currentTimer = isPlayer1Turn ? player1Timer : player2Timer;
        playerInfoText.text = $"{currentPlayerName}: {currentTimer:F2} segundos";
    }

    // Carrega o próximo arquivo JSON e reposiciona os objetos
    public void LoadAllObjects()
    {
        if (jsonFiles == null || jsonFiles.Length == 0)
        {
            Debug.LogError("Nenhum arquivo JSON disponível para carregar!");
            return;
        }

        if (currentFileIndex >= jsonFiles.Length)
        {
            Debug.Log("Todos os arquivos JSON já foram carregados.");
            Debug.Log("curent file:"+currentFileIndex);
            Debug.Log("json lenght:"+jsonFiles.Length);
            

            // Chama a função que indica que todos os JSONs foram concluídos
            TerminarTangram();
            return;
        }

        try
        {
            //muda jogador
            SwitchPlayer();


            // Lê o conteúdo do arquivo JSON atual
            string json = jsonFiles[currentFileIndex].text;
            Debug.Log($"Carregando JSON: {jsonFiles[currentFileIndex].name}\nConteúdo:\n{json}");

            // Deserializa o JSON para uma lista de objetos
            var objectsData = JsonConvert.DeserializeObject<List<ObjectData>>(json);
            if (objectsData == null || objectsData.Count == 0)
            {
                Debug.LogWarning($"O arquivo {jsonFiles[currentFileIndex].name} está vazio ou não contém objetos válidos.");
                return;
            }

            // Reposiciona os objetos com base nos dados carregados
            foreach (ObjectData data in objectsData)
            {
                GameObject obj = objectsToLoad.Find(o => o.name == data.name);
                if (obj != null)
                {
                    if (obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
                    {
                        rectTransform.anchoredPosition = data.position;
                        rectTransform.rotation = Quaternion.Euler(0, 0, data.rotation);
                        Debug.Log($"[UI] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
                    }
                    else
                    {
                        obj.transform.position = new Vector3(data.position.x, data.position.y, obj.transform.position.z);
                        obj.transform.rotation = Quaternion.Euler(0, 0, data.rotation);
                        Debug.Log($"[Transform] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
                    }
                }
                else
                {
                    Debug.LogWarning($"Objeto com o nome {data.name} não encontrado na lista de objetos para carregar.");
                }
            }

            // Incrementa os pontos do jogador atual
            if (isPlayer1Turn)
            {
                player1Points++;
            }
            else
            {
                player2Points++;
            }

            // Avança para o próximo arquivo JSON
            currentFileIndex++;
        }
        catch (JsonException ex)
        {
            Debug.LogError($"Erro ao processar o arquivo JSON {jsonFiles[currentFileIndex].name}: {ex.Message}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Erro inesperado ao carregar o JSON {jsonFiles[currentFileIndex].name}: {ex.Message}");
        }
    }

    private void SwitchPlayer()
    {
        isPlayer1Turn = !isPlayer1Turn;
    }

    // Função chamada quando todos os JSONs forem concluídos
    private void TerminarTangram()
    {
        Debug.Log("Todos os Tangrams foram concluídos! Você pode adicionar lógica aqui, como avançar para a próxima fase ou mostrar uma mensagem de vitória.");

        string player1Name = PlayerPrefs.GetString("CurrentPlayer1Name_multi", "Player 1");
        string player2Name = PlayerPrefs.GetString("CurrentPlayer2Name_multi", "Player 2");

        string winner = player1Timer > player2Timer ? player1Name : player2Name;
        Debug.Log($"O vencedor é: {winner}");

        // Exibe os resultados no TextMeshPro
        playerInfoText.text = $"Vencedor: {winner}\n{player1Name}: {player1Points} pontos\n{player2Name}: {player2Points} pontos";

        PlayerPrefs.SetString("winner", winner);
        SceneManager.LoadScene(sceneName); // Nome da cena que será carregada
    }

    // Classe para armazenar os dados de posição e rotação
    private class ObjectData
    {
        public string name;
        public Vector2 position;
        public float rotation;
    }
}
