// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Load_Pieces : MonoBehaviour
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

//==============================================================================

// using UnityEngine;
// using System.Collections.Generic;
// using System.IO;
// using Newtonsoft.Json;

// public class LoadManager : MonoBehaviour
// {
//     [Tooltip("Lista de objetos que possuem o script DragAndSave")]
//     public List<GameObject> objectsToLoad;

//     [Tooltip("Caminho do arquivo JSON")]
//     public string customFilePath = "";

//     private string filePath;

//     private void Start()
//     {
//         // Define o caminho do arquivo se não for configurado manualmente
//         filePath = string.IsNullOrEmpty(customFilePath)
//             ? Path.Combine(Application.persistentDataPath, "saved_positions.json")
//             : customFilePath;

//         Debug.Log($"Arquivo de carregamento: {filePath}");
//     }

//     // Carrega os dados do arquivo JSON e reposiciona os objetos
//     public void LoadAllObjects()
//     {
//         if (!File.Exists(filePath))
//         {
//             Debug.LogError($"Arquivo {filePath} não encontrado!");
//             return;
//         }

//         string json = File.ReadAllText(filePath);
//         var objectsData = JsonConvert.DeserializeObject<List<ObjectData>>(json);

//         foreach (ObjectData data in objectsData)
//         {
//             GameObject obj = objectsToLoad.Find(o => o.name == data.name);
//             if (obj != null && obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
//             {
//                 rectTransform.anchoredPosition = data.position;
//                 rectTransform.rotation = Quaternion.Euler(0, 0, data.rotation);

//                 Debug.Log($"Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
//             }
//         }
//     }

//     // Classe para armazenar os dados de posição e rotação
//     private class ObjectData
//     {
//         public string name;
//         public Vector2 position;
//         public float rotation;
//     }
// }

// novo testando ================================================



// public void LoadAllObjects()
// {
//     if (!File.Exists(filePath))
//     {
//         Debug.LogError($"Arquivo {filePath} não encontrado!");
//         return;
//     }

//     string json = File.ReadAllText(filePath);
//     var objectsData = JsonConvert.DeserializeObject<List<ObjectData>>(json);

//     foreach (ObjectData data in objectsData)
//     {
//         GameObject obj = objectsToLoad.Find(o => o.name == data.name);
//         if (obj != null)
//         {
//             // Verifica se é um elemento UI (RectTransform) ou objeto comum (Transform)
//             if (obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
//             {
//                 rectTransform.anchoredPosition = data.position;
//                 rectTransform.rotation = Quaternion.Euler(0, 0, data.rotation);
//                 Debug.Log($"[UI] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
//             }
//             else
//             {
//                 obj.transform.position = new Vector3(data.position.x, data.position.y, obj.transform.position.z);
//                 obj.transform.rotation = Quaternion.Euler(0, 0, data.rotation);
//                 Debug.Log($"[Transform] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
//             }
//         }
//         else
//         {
//             Debug.LogWarning($"Objeto com o nome {data.name} não encontrado na lista.");
//         }
//     }
// }



// esse aqui esta funcionando =============================================


// using UnityEngine;
// using System.Collections.Generic;
// using System.IO;
// using Newtonsoft.Json;

// public class LoadManager : MonoBehaviour
// {
//     [Tooltip("Lista de objetos que possuem o script DragAndSave")]
//     public List<GameObject> objectsToLoad;

//     [Tooltip("Caminho do arquivo JSON")]
//     public string customFilePath = "";

//     private string filePath;

//     private void Start()
//     {
//         // Define o caminho do arquivo se não for configurado manualmente
//         filePath = string.IsNullOrEmpty(customFilePath)
//             ? Path.Combine(Application.persistentDataPath, "saved_positions.json")
//             : customFilePath;

//         Debug.Log($"Arquivo de carregamento: {filePath}");
//         LoadAllObjects();
//     }

//     // Carrega os dados do arquivo JSON e reposiciona os objetos
//     public void LoadAllObjects()
//     {
//         if (!File.Exists(filePath))
//         {
//             Debug.LogError($"Arquivo {filePath} não encontrado!");
//             return;
//         }

//         try
//         {
//             // Lê o conteúdo do arquivo JSON
//             string json = File.ReadAllText(filePath);
//             Debug.Log($"Conteúdo do JSON lido:\n{json}");

//             // Deserializa o JSON para uma lista de objetos
//             var objectsData = JsonConvert.DeserializeObject<List<ObjectData>>(json);
//             if (objectsData == null || objectsData.Count == 0)
//             {
//                 Debug.LogWarning("O JSON está vazio ou não contém objetos válidos.");
//                 return;
//             }

//             // Reposiciona os objetos com base nos dados carregados
//             foreach (ObjectData data in objectsData)
//             {
//                 GameObject obj = objectsToLoad.Find(o => o.name == data.name);
//                 if (obj != null)
//                 {
//                     // Verifica se é um elemento UI (RectTransform) ou objeto comum (Transform)
//                     if (obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
//                     {
//                         rectTransform.anchoredPosition = data.position;
//                         rectTransform.rotation = Quaternion.Euler(0, 0, data.rotation);
//                         Debug.Log($"[UI] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
//                     }
//                     else
//                     {
//                         obj.transform.position = new Vector3(data.position.x, data.position.y, obj.transform.position.z);
//                         obj.transform.rotation = Quaternion.Euler(0, 0, data.rotation);
//                         Debug.Log($"[Transform] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
//                     }
//                 }
//                 else
//                 {
//                     Debug.LogWarning($"Objeto com o nome {data.name} não encontrado na lista de objetos para carregar.");
//                 }
//             }
//         }
//         catch (JsonException ex)
//         {
//             Debug.LogError($"Erro ao processar o arquivo JSON: {ex.Message}");
//         }
//         catch (System.Exception ex)
//         {
//             Debug.LogError($"Erro inesperado ao carregar os objetos: {ex.Message}");
//         }
//     }

//     // Classe para armazenar os dados de posição e rotação
//     private class ObjectData
//     {
//         public string name;
//         public Vector2 position;
//         public float rotation;
//     }
// }

// ================================== novo pegando do ressorces =============


// using UnityEngine;
// using System.Collections.Generic;
// using Newtonsoft.Json;

// public class LoadManager : MonoBehaviour
// {
//     [Tooltip("Lista de objetos que possuem o script DragAndSave")]
//     public List<GameObject> objectsToLoad;

//     [Tooltip("Nome da pasta dentro de Resources")]
//     public string resourcesFolder = "Tangram";

//     private TextAsset[] jsonFiles; // Lista de arquivos JSON na pasta Resources/Tangram
//     private int currentFileIndex = 0; // Índice do arquivo JSON atual

//     private float timer; // Timer para contabilizar o tempo

//     private void Start()
//     {
//         // Carrega todos os arquivos JSON da pasta Resources/Tangram
//         jsonFiles = Resources.LoadAll<TextAsset>(resourcesFolder);

//         if (jsonFiles.Length == 0)
//         {
//             Debug.LogError("Nenhum arquivo JSON encontrado na pasta Resources/Tangram!");
//             return;
//         }

//         Debug.Log($"Total de arquivos JSON carregados: {jsonFiles.Length}");

//         // Inicializa o timer
//         timer = 0f;

//         // Carrega o primeiro arquivo JSON
//         LoadAllObjects();
//     }

//     private void Update()
//     {
//         // Incrementa o timer
//         timer += Time.deltaTime;
//     }

//     // Carrega o próximo arquivo JSON e reposiciona os objetos
//     public void LoadAllObjects()
//     {
//         if (jsonFiles == null || jsonFiles.Length == 0)
//         {
//             Debug.LogError("Nenhum arquivo JSON disponível para carregar!");
//             return;
//         }

//         if (currentFileIndex >= jsonFiles.Length)
//         {
//             Debug.Log("Todos os arquivos JSON já foram carregados.");
//             return;
//         }

//         try
//         {
//             // Lê o conteúdo do arquivo JSON atual
//             string json = jsonFiles[currentFileIndex].text;
//             Debug.Log($"Carregando JSON: {jsonFiles[currentFileIndex].name}\nConteúdo:\n{json}");

//             // Deserializa o JSON para uma lista de objetos
//             var objectsData = JsonConvert.DeserializeObject<List<ObjectData>>(json);
//             if (objectsData == null || objectsData.Count == 0)
//             {
//                 Debug.LogWarning($"O arquivo {jsonFiles[currentFileIndex].name} está vazio ou não contém objetos válidos.");
//                 return;
//             }

//             // Reposiciona os objetos com base nos dados carregados
//             foreach (ObjectData data in objectsData)
//             {
//                 GameObject obj = objectsToLoad.Find(o => o.name == data.name);
//                 if (obj != null)
//                 {
//                     if (obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
//                     {
//                         rectTransform.anchoredPosition = data.position;
//                         rectTransform.rotation = Quaternion.Euler(0, 0, data.rotation);
//                         Debug.Log($"[UI] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
//                     }
//                     else
//                     {
//                         obj.transform.position = new Vector3(data.position.x, data.position.y, obj.transform.position.z);
//                         obj.transform.rotation = Quaternion.Euler(0, 0, data.rotation);
//                         Debug.Log($"[Transform] Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
//                     }
//                 }
//                 else
//                 {
//                     Debug.LogWarning($"Objeto com o nome {data.name} não encontrado na lista de objetos para carregar.");
//                 }
//             }

//             // Avança para o próximo arquivo JSON
//             currentFileIndex++;
//         }
//         catch (JsonException ex)
//         {
//             Debug.LogError($"Erro ao processar o arquivo JSON {jsonFiles[currentFileIndex].name}: {ex.Message}");
//         }
//         catch (System.Exception ex)
//         {
//             Debug.LogError($"Erro inesperado ao carregar o JSON {jsonFiles[currentFileIndex].name}: {ex.Message}");
//         }
//     }

//     // Classe para armazenar os dados de posição e rotação
//     private class ObjectData
//     {
//         public string name;
//         public Vector2 position;
//         public float rotation;
//     }
// }



// ================enviando o ranking pra RankingScene==================================

using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [Tooltip("Lista de objetos que possuem o script DragAndSave")]
    public List<GameObject> objectsToLoad;

    [Tooltip("Nome da pasta dentro de Resources")]
    public string resourcesFolder = "Tangram";

    private TextAsset[] jsonFiles; // Lista de arquivos JSON na pasta Resources/Tangram
    private int currentFileIndex = 0; // Índice do arquivo JSON atual

    private float timer; // Timer para contabilizar o tempo

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

        // Inicializa o timer
        timer = 0f;

        // Carrega o primeiro arquivo JSON
        LoadAllObjects();
    }

    private void Update()
    {
        // Incrementa o timer
        timer += Time.deltaTime;
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

            // Chama a função que indica que todos os JSONs foram concluídos
            TerminarTangram();
            return;
        }

        try
        {
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

    // Função chamada quando todos os JSONs forem concluídos
    private void TerminarTangram()
    {
        Debug.Log("Todos os Tangrams foram concluídos! Você pode adicionar lógica aqui, como avançar para a próxima fase ou mostrar uma mensagem de vitória.");

        string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName", "Player1");
        // Exemplo de lógica adicional:
        SubmitScore(currentPlayerName, timer);
    }

    // Submete o placar e carrega a cena do ranking
    private void SubmitScore(string playerName, float playerTime)
    {
        // Envia o nome e o tempo para o PlayerPrefs
        PlayerPrefs.SetString("CurrentPlayerName", playerName);
        PlayerPrefs.SetFloat("CurrentPlayerTime", playerTime);

        // Adiciona o jogador ao ranking existente
        int rankCount = PlayerPrefs.GetInt("RankingCount", 0);
        PlayerPrefs.SetString($"PlayerName_{rankCount}", playerName);
        PlayerPrefs.SetFloat($"PlayerTime_{rankCount}", playerTime);
        PlayerPrefs.SetInt("RankingCount", rankCount + 1);

        // Carrega a cena do ranking
        SceneManager.LoadScene("RankingScene");
    }

    // Classe para armazenar os dados de posição e rotação
    private class ObjectData
    {
        public string name;
        public Vector2 position;
        public float rotation;
    }
}
