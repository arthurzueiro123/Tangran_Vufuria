
// using UnityEngine;
// using UnityEngine.SceneManagement; // Importante para carregar a cena

// public class IrParaTelaNome : MonoBehaviour
// {
//     // Método para carregar a cena de inserção de nome
//     public void IrParaTelaNome(string sceneName)
//     {
//         SceneManager.LoadScene(sceneName); // Nome da cena que será carregada
//     }
// }


// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI; // Necessário para usar o InputField

// public class IrParaTelaNome : MonoBehaviour
// {
//     public InputField playerNameInput; // Referência ao InputField na UI

//     // Método para salvar o nome do jogador e carregar a cena de inserção de nome
//     public void IrParaTelaJogo(string sceneName)
//     {
//         if (playerNameInput != null)
//         {
//             string playerName = playerNameInput.text;

//             // Salvar o nome no PlayerPrefs
//             PlayerPrefs.SetString("CurrentPlayerName", playerName);
//             PlayerPrefs.Save(); // Certifique-se de que os dados sejam gravados

//             Debug.Log("Nome do jogador salvo: " + playerName);
//         }
//         else
//         {
//             Debug.LogWarning("InputField de nome do jogador não está configurado!");
//         }

//         SceneManager.LoadScene(sceneName); // Nome da cena que será carregada
//     }
// }


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necessário para usar o InputField
using TMPro; // Necessário para usar o TMP_InputField

public class IrParaTelaNome : MonoBehaviour
{
    // public InputField playerNameInput; // Para o InputField padrão do Unity
    public TMP_InputField playerNameTMPInput; // Para o TMP_InputField do TextMeshPro

    // Método para salvar o nome do jogador e carregar a cena
    public void IrParaTelaIniciar(string sceneName)
    {
        string playerName = "";

        // Prioriza TMP_InputField se estiver configurado
        if (playerNameTMPInput != null)
        {
            playerName = playerNameTMPInput.text;
        }
        // else if (playerNameInput != null) // Usa InputField padrão se TMP_InputField não estiver configurado
        // {
        //     playerName = playerNameInput.text;
        // }
        else
        {
            Debug.LogWarning("Nenhum campo de entrada configurado!");
            return; // Sai do método se nenhum campo estiver configurado
        }

        // Verifica se o nome não está vazio
        if (!string.IsNullOrEmpty(playerName))
        {
            // Salvar o nome no PlayerPrefs
            PlayerPrefs.SetString("CurrentPlayerName", playerName);
            PlayerPrefs.Save(); // Certifique-se de que os dados sejam gravados

            Debug.Log("Nome do jogador salvo: " + playerName);

            // Carrega a cena especificada
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("O nome do jogador não pode estar vazio!");
        }
    }
}
