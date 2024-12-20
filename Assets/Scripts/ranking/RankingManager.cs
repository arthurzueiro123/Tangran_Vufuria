// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NewBehaviourScript : MonoBehaviour
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

//============================================ não testado =======================================

// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections.Generic;
// using System.Linq;

// public class RankingManager : MonoBehaviour
// {
//     public GameObject rankingContainer; // Um GameObject vazio para conter os textos do ranking
//     public GameObject rankingEntryPrefab; // Prefab para exibir cada entrada do ranking

//     private void Start()
//     {
//         DisplayRanking();
//     }

//     private void DisplayRanking()
//     {
//         // Carrega os dados do ranking
//         int rankCount = PlayerPrefs.GetInt("RankingCount", 0);
//         List<PlayerData> ranking = new List<PlayerData>();

//         for (int i = 0; i < rankCount; i++)
//         {
//             string playerName = PlayerPrefs.GetString($"PlayerName_{i}", "Unknown");
//             float playerTime = PlayerPrefs.GetFloat($"PlayerTime_{i}", float.MaxValue);
//             ranking.Add(new PlayerData(playerName, playerTime));
//         }

//         // Ordena por tempo (menor tempo primeiro)
//         ranking = ranking.OrderBy(p => p.time).ToList();

//         // Nome e tempo do jogador atual
//         string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName", "Unknown");
//         float currentPlayerTime = PlayerPrefs.GetFloat("CurrentPlayerTime", float.MaxValue);

//         // Exibe o ranking
//         foreach (PlayerData player in ranking)
//         {
//             GameObject entry = Instantiate(rankingEntryPrefab, rankingContainer.transform);
//             Text entryText = entry.GetComponent<Text>();

//             // Destaque a pontuação atual
//             if (player.playerName == currentPlayerName && Mathf.Approximately(player.time, currentPlayerTime))
//             {
//                 entryText.text = $"<b>{player.playerName} - {player.time:F2}s</b>";
//                 entryText.color = Color.green;
//             }
//             else
//             {
//                 entryText.text = $"{player.playerName} - {player.time:F2}s";
//             }
//         }
//     }
// }

// [System.Serializable]
// public class PlayerData
// {
//     public string playerName;
//     public float time;

//     public PlayerData(string playerName, float time)
//     {
//         this.playerName = playerName;
//         this.time = time;
//     }
// }

//==================com o entreyprefab com texto e imagem ===================================


// using UnityEngine;
// using TMPro; // Usando TextMeshPro
// using System.Collections.Generic;
// using System.Linq;

// public class RankingManager : MonoBehaviour
// {
//     public GameObject rankingContainer; // Um GameObject vazio para conter os textos do ranking
//     public GameObject rankingEntryPrefab; // Prefab para exibir cada entrada do ranking

//     private void Start()
//     {
//         DisplayRanking();
//     }

//     private void DisplayRanking()
//     {
//         // Carrega os dados do ranking
//         int rankCount = PlayerPrefs.GetInt("RankingCount", 0);
//         List<PlayerData> ranking = new List<PlayerData>();

//         for (int i = 0; i < rankCount; i++)
//         {
//             string playerName = PlayerPrefs.GetString($"PlayerName_{i}", "Unknown");
//             float playerTime = PlayerPrefs.GetFloat($"PlayerTime_{i}", float.MaxValue);
//             ranking.Add(new PlayerData(playerName, playerTime));
//         }

//         // Ordena por tempo (menor tempo primeiro)
//         ranking = ranking.OrderBy(p => p.time).ToList();

//         // Nome e tempo do jogador atual
//         string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName", "Unknown");
//         float currentPlayerTime = PlayerPrefs.GetFloat("CurrentPlayerTime", float.MaxValue);

//         // Exibe o ranking
//         foreach (PlayerData player in ranking)
//         {
//             // Instancia a entrada de ranking (RankingEntryPrefab)
//             GameObject entry = Instantiate(rankingEntryPrefab, rankingContainer.transform);

//             // Referência para a imagem de fundo e o texto (TextMeshPro)
//             Image entryBackground = entry.GetComponentInChildren<Image>();  // Obtem a imagem (componente de fundo)
//             TextMeshProUGUI entryText = entry.GetComponentInChildren<TextMeshProUGUI>();  // Obtem o texto

//             // Ajusta o texto com o nome e tempo
//             if (player.playerName == currentPlayerName && Mathf.Approximately(player.time, currentPlayerTime))
//             {
//                 // Destaque para a pontuação atual
//                 entryText.text = $"<b>{player.playerName} - {player.time:F2}s</b>";
//                 entryText.color = Color.green;
//             }
//             else
//             {
//                 entryText.text = $"{player.playerName} - {player.time:F2}s";
//             }

//             // (Opcional) Se você quiser personalizar a imagem de fundo para o jogador atual, por exemplo:
//             if (player.playerName == currentPlayerName && Mathf.Approximately(player.time, currentPlayerTime))
//             {
//                 entryBackground.color = Color.yellow; // Destaque com uma cor diferente para o fundo
//             }
//         }
//     }
// }

// [System.Serializable]
// public class PlayerData
// {
//     public string playerName;
//     public float time;

//     public PlayerData(string playerName, float time)
//     {
//         this.playerName = playerName;
//         this.time = time;
//     }
// }


// using UnityEngine;
// using UnityEngine.UI; // Necessário para o Image (Unity UI)
// using TMPro; // Necessário para o TextMeshPro
// using System.Collections.Generic;
// using System.Linq;

// public class RankingManager : MonoBehaviour
// {
//     public GameObject rankingContainer; // Um GameObject vazio para conter os textos do ranking
//     public GameObject rankingEntryPrefab; // Prefab para exibir cada entrada do ranking

//     private void Start()
//     {
//         DisplayRanking();
//     }

//     private void DisplayRanking()
//     {
//         // Carrega os dados do ranking
//         int rankCount = PlayerPrefs.GetInt("RankingCount", 0);
//         List<PlayerData> ranking = new List<PlayerData>();

//         for (int i = 0; i < rankCount; i++)
//         {
//             string playerName = PlayerPrefs.GetString($"PlayerName_{i}", "Unknown");
//             float playerTime = PlayerPrefs.GetFloat($"PlayerTime_{i}", float.MaxValue);
//             ranking.Add(new PlayerData(playerName, playerTime));
//         }

//         // Ordena por tempo (menor tempo primeiro)
//         ranking = ranking.OrderBy(p => p.time).ToList();

//         // Nome e tempo do jogador atual
//         string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName", "Unknown");
//         float currentPlayerTime = PlayerPrefs.GetFloat("CurrentPlayerTime", float.MaxValue);

//         // Exibe o ranking
//         foreach (PlayerData player in ranking)
//         {
//             // Instancia a entrada de ranking (RankingEntryPrefab)
//             GameObject entry = Instantiate(rankingEntryPrefab, rankingContainer.transform);

//             // Referência para a imagem de fundo e o texto (TextMeshPro)
//             Image entryBackground = entry.GetComponentInChildren<Image>();  // Obtem a imagem (componente de fundo)
//             TextMeshProUGUI entryText = entry.GetComponentInChildren<TextMeshProUGUI>();  // Obtem o texto

//             // Ajusta o texto com o nome e tempo
//             if (player.playerName == currentPlayerName && Mathf.Approximately(player.time, currentPlayerTime))
//             {
//                 // Destaque para a pontuação atual
//                 entryText.text = $"<b>{player.playerName} - {player.time:F2}s</b>";
//                 entryText.color = Color.green;
//             }
//             else
//             {
//                 entryText.text = $"{player.playerName} - {player.time:F2}s";
//             }

//             // (Opcional) Se você quiser personalizar a imagem de fundo para o jogador atual, por exemplo:
//             if (player.playerName == currentPlayerName && Mathf.Approximately(player.time, currentPlayerTime))
//             {
//                 entryBackground.color = Color.yellow; // Destaque com uma cor diferente para o fundo
//             }
//         }
//     }
// }

// [System.Serializable]
// public class PlayerData
// {
//     public string playerName;
//     public float time;

//     public PlayerData(string playerName, float time)
//     {
//         this.playerName = playerName;
//         this.time = time;
//     }
// }


// corrigindo posição y

using UnityEngine;
using UnityEngine.UI; // Necessário para o Image (Unity UI)
using TMPro; // Necessário para o TextMeshPro
using System.Collections.Generic;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public GameObject rankingContainer; // Um GameObject vazio para conter os textos do ranking
    public GameObject rankingEntryPrefab; // Prefab para exibir cada entrada do ranking
    public float entryHeight = 80f; // Altura entre cada entrada no ranking

    private void Start()
    {
        DisplayRanking();
    }

    private void DisplayRanking()
    {
        // Carrega os dados do ranking
        int rankCount = PlayerPrefs.GetInt("RankingCount", 0);
        List<PlayerData> ranking = new List<PlayerData>();

        for (int i = 0; i < rankCount; i++)
        {
            string playerName = PlayerPrefs.GetString($"PlayerName_{i}", "Unknown");
            float playerTime = PlayerPrefs.GetFloat($"PlayerTime_{i}", float.MaxValue);
            ranking.Add(new PlayerData(playerName, playerTime));
        }

        // Ordena por tempo (menor tempo primeiro)
        ranking = ranking.OrderBy(p => p.time).ToList();

        // Nome e tempo do jogador atual
        string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName", "Unknown");
        float currentPlayerTime = PlayerPrefs.GetFloat("CurrentPlayerTime", float.MaxValue);

        // Exibe o ranking, mas mostra apenas os 5 primeiros jogadores
        float yOffset = -140f; // Variável para ajustar a posição Y dinamicamente

        for (int i = 0; i < Mathf.Min(5, ranking.Count); i++) // Exibe apenas os 5 primeiros
        {
            PlayerData player = ranking[i];

            // Instancia a entrada de ranking (RankingEntryPrefab)
            GameObject entry = Instantiate(rankingEntryPrefab, rankingContainer.transform);

            // Ajusta a posição Y da entrada para que elas não se sobreponham
            RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0f, -yOffset); // Ajuste da posição Y

            // Referência para a imagem de fundo e o texto (TextMeshPro)
            Image entryBackground = entry.GetComponentInChildren<Image>();  // Obtém a imagem (componente de fundo)
            TextMeshProUGUI entryText = entry.GetComponentInChildren<TextMeshProUGUI>();  // Obtém o texto

            // Ajusta o texto com o nome e tempo
            if (player.playerName == currentPlayerName && Mathf.Approximately(player.time, currentPlayerTime))
            {
                // Destaque para a pontuação atual
                entryText.text = $"<b>{player.playerName} - {player.time:F2}s</b>";
                entryText.color = Color.green;
            }
            else
            {
                entryText.text = $"{player.playerName} - {player.time:F2}s";
            }

            // (Opcional) Se você quiser personalizar a imagem de fundo para o jogador atual, por exemplo:
            if (player.playerName == currentPlayerName && Mathf.Approximately(player.time, currentPlayerTime))
            {
                entryBackground.color = Color.yellow; // Destaque com uma cor diferente para o fundo
            }

            // Incrementa o valor do yOffset para que a próxima entrada fique abaixo
            yOffset += entryHeight;
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public float time;

    public PlayerData(string playerName, float time)
    {
        this.playerName = playerName;
        this.time = time;
    }
}
