using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necessário para usar o InputField
using TMPro; // Necessário para usar o TMP_InputField

public class IrParaTelaMulti : MonoBehaviour
{
    // public InputField playerNameInput; // Para o InputField padrão do Unity
    public TMP_InputField playerNameTMPInput; // Para o TMP_InputField do TextMeshPro

    public TMP_InputField player2NameTMPInput;
    // Método para salvar o nome do jogador e carregar a cena
    public void IrParaTela(string sceneName)
    {
        string playerName = "";

        string player2Name = "";

        // Prioriza TMP_InputField se estiver configurado
        if (playerNameTMPInput != null && player2NameTMPInput != null )
        {
            playerName = playerNameTMPInput.text;
            player2Name = player2NameTMPInput.text;
            
        }else
        {
            Debug.LogWarning("Nenhum campo de entrada configurado!");
            return; // Sai do método se nenhum campo estiver configurado
        }

        // Verifica se o nome não está vazio
        if (!string.IsNullOrEmpty(playerName) && !string.IsNullOrEmpty(player2Name))
        {
            // Salvar o nome no PlayerPrefs
            PlayerPrefs.SetString("CurrentPlayer1Name_multi", playerName);
            PlayerPrefs.SetString("CurrentPlayer2Name_multi", player2Name);
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
