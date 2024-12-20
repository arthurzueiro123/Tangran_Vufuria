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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerPosition : MonoBehaviour
{
    public GameObject imageTarget; // Arraste seu ImageTarget aqui
    public Camera arCamera;       // Arraste a ARCamera aqui

    void Update()
    {
        if (imageTarget != null && arCamera != null)
        {
            // Obter a posição no espaço do mundo
            Vector3 worldPosition = imageTarget.transform.position;

            // Converter para o espaço da janela da câmera
            Vector3 screenPosition = arCamera.WorldToScreenPoint(worldPosition);

            // Exibir informações no console
            Debug.Log($"Posição no mundo: {worldPosition}");
            Debug.Log($"Posição na tela: {screenPosition}");
        }
    }
}
