// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class NewBehaviourScript : MonoBehaviour
// // {
// //     // Start is called before the first frame update
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// // }



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
//                 entryText.color = Color.green;// cor em destaque do atual
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
