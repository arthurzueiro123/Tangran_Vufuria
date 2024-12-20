// using UnityEngine;
// using UnityEngine.SceneManagement; // Importante para carregar a cena

// public class TelaInicial : MonoBehaviour
// {
//     // Método para carregar a cena de inserção de nome
//     public string Scene_name = "Individual";
//     public void IrParaTelaNome(string Scene_name)
//     {
//         SceneManager.LoadScene(Scene_name); // Nome da cena que será carregada
//     }
// }


using UnityEngine;
using UnityEngine.SceneManagement; // Importante para carregar a cena

public class TelaInicial : MonoBehaviour
{
    // Método para carregar a cena de inserção de nome
    public void IrParaTelaNome(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Nome da cena que será carregada
    }
}
