using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerCollision : MonoBehaviour
{
    public GameObject imageTarget; // Referência ao marcador (ImageTarget)
    public Camera arCamera;        // ARCamera da cena
    public RectTransform colliderUI; // Colisor na interface (UI)
    private bool objectsDestroyed = false; // Flag para evitar repetição de destruição

    void Update()
    {
        if (imageTarget != null && arCamera != null && colliderUI != null)
        {
            // Obter a posição do marcador na tela (2D)
            Vector3 markerScreenPosition = arCamera.WorldToScreenPoint(imageTarget.transform.position);

            // Verificar se a posição do marcador está dentro do colisor
            bool isColliding = RectTransformUtility.RectangleContainsScreenPoint(colliderUI, markerScreenPosition, null);

            // Se houver colisão e os filhos ainda não foram destruídos
            if (isColliding && !objectsDestroyed)
            {
                Debug.Log("O marcador está no colisor!");

                // Mudar a cor para verde
                colliderUI.GetComponent<Image>().color = new Color(0, 255, 0, 100); // Verde

                // Excluir filhos diretos do ImageTarget
                foreach (Transform child in imageTarget.transform)
                {
                    Destroy(child.gameObject); // Destruir cada filho direto
                }

                // Evitar repetição de destruição
                objectsDestroyed = true;
            }
        }
    }
}

