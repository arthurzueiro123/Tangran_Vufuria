// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class MarkerCollisionMapping : MonoBehaviour
// {
//     [System.Serializable]
//     public class TargetColliderPair
//     {
//         public GameObject imageTarget;   // Referência ao marcador (ImageTarget)
//         public RectTransform colliderUI; // Colisor na interface (UI)
//     }

//     public Camera arCamera;                    // ARCamera da cena
//     public TargetColliderPair[] targetColliderPairs; // Lista de pares (ImageTarget -> Collider)

//     private bool[] objectsDestroyedFlags;      // Flags para evitar repetição de destruição

//     void Start()
//     {
//         // Inicializar as flags para cada par
//         objectsDestroyedFlags = new bool[targetColliderPairs.Length];
//     }

//     void Update()
//     {
//         for (int i = 0; i < targetColliderPairs.Length; i++)
//         {
//             TargetColliderPair pair = targetColliderPairs[i];

//             if (pair.imageTarget != null && arCamera != null && pair.colliderUI != null)
//             {
//                 // Obter a posição do marcador na tela (2D)
//                 Vector3 markerScreenPosition = arCamera.WorldToScreenPoint(pair.imageTarget.transform.position);

//                 // Verificar se a posição do marcador está dentro do colisor
//                 bool isColliding = RectTransformUtility.RectangleContainsScreenPoint(pair.colliderUI, markerScreenPosition, null);

//                 // Se houver colisão e os filhos ainda não foram destruídos
//                 if (isColliding && !objectsDestroyedFlags[i])
//                 {
//                     Debug.Log($"O marcador '{pair.imageTarget.name}' está no colisor '{pair.colliderUI.name}'!");

//                     // Mudar a cor do colisor para verde
//                     pair.colliderUI.GetComponent<Image>().color = new Color(0, 255, 0, 100); // Verde

//                     // Excluir filhos diretos do ImageTarget
//                     foreach (Transform child in pair.imageTarget.transform)
//                     {
//                         Destroy(child.gameObject); // Destruir cada filho direto
//                     }

//                     // Marcar como já processado
//                     objectsDestroyedFlags[i] = true;
//                 }
//             }
//         }
//     }
// }

//=============================tava ok

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class MarkerCollisionMapping : MonoBehaviour
// {
//     [System.Serializable]
//     public class TargetColliderPair
//     {
//         public GameObject imageTarget;   // Referência ao marcador (ImageTarget)
//         public RectTransform colliderUI; // Colisor na interface (UI)
//         public Color collisionColor;     // Cor a ser aplicada no colisor ao detectar colisão
//     }

//     public Camera arCamera;                    // ARCamera da cena
//     public TargetColliderPair[] targetColliderPairs; // Lista de pares (ImageTarget -> Collider)

//     private bool[] objectsDestroyedFlags;      // Flags para evitar repetição de destruição

//     void Start()
//     {
//         // Inicializar as flags para cada par
//         objectsDestroyedFlags = new bool[targetColliderPairs.Length];
//     }

//     void Update()
//     {
//         for (int i = 0; i < targetColliderPairs.Length; i++)
//         {
//             TargetColliderPair pair = targetColliderPairs[i];

//             if (pair.imageTarget != null && arCamera != null && pair.colliderUI != null)
//             {
//                 // Obter a posição do marcador na tela (2D)
//                 Vector3 markerScreenPosition = arCamera.WorldToScreenPoint(pair.imageTarget.transform.position);

//                 // Verificar se a posição do marcador está dentro do colisor
//                 bool isColliding = RectTransformUtility.RectangleContainsScreenPoint(pair.colliderUI, markerScreenPosition, null);

//                 // Se houver colisão e os filhos ainda não foram destruídos
//                 if (isColliding && !objectsDestroyedFlags[i])
//                 {
//                     Debug.Log($"O marcador '{pair.imageTarget.name}' está no colisor '{pair.colliderUI.name}'!");

//                     // Mudar a cor do colisor para a cor definida no par
//                     pair.colliderUI.GetComponent<Image>().color = pair.collisionColor;

//                     // Excluir filhos diretos do ImageTarget
//                     foreach (Transform child in pair.imageTarget.transform)
//                     {
//                         Destroy(child.gameObject); // Destruir cada filho direto
//                     }

//                     // Marcar como já processado
//                     objectsDestroyedFlags[i] = true;
//                 }
//             }
//         }
//     }
// }


//================================== adicionado funcoes para detectar colisão cada peça e final ==========

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class MarkerCollisionMapping : MonoBehaviour
// {
//     [System.Serializable]
//     public class TargetColliderPair
//     {
//         public GameObject imageTarget;   // Referência ao marcador (ImageTarget)
//         public RectTransform colliderUI; // Colisor na interface (UI)
//         public Color collisionColor;     // Cor a ser aplicada no colisor ao detectar colisão
//     }

//     public Camera arCamera;                    // ARCamera da cena
//     public TargetColliderPair[] targetColliderPairs; // Lista de pares (ImageTarget -> Collider)

//     private bool[] objectsDestroyedFlags;      // Flags para evitar repetição de destruição
//     private int completedPieces = 0;           // Contador de peças processadas

//     void Start()
//     {
//         // Inicializar as flags para cada par e ajustar a cor inicial das imagens
//         objectsDestroyedFlags = new bool[targetColliderPairs.Length];
//         foreach (var pair in targetColliderPairs)
//         {
//             if (pair.colliderUI != null)
//             {
//                 // Definir a cor inicial preta com 40% de alpha
//                 pair.colliderUI.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
//             }
//         }
//     }

//     void Update()
//     {
//         for (int i = 0; i < targetColliderPairs.Length; i++)
//         {
//             TargetColliderPair pair = targetColliderPairs[i];

//             if (pair.imageTarget != null && arCamera != null && pair.colliderUI != null)
//             {
//                 // Obter a posição do marcador na tela (2D)
//                 Vector3 markerScreenPosition = arCamera.WorldToScreenPoint(pair.imageTarget.transform.position);

//                 // Verificar se a posição do marcador está dentro do colisor
//                 bool isColliding = RectTransformUtility.RectangleContainsScreenPoint(pair.colliderUI, markerScreenPosition, null);

//                 // Se houver colisão e os filhos ainda não foram destruídos
//                 if (isColliding && !objectsDestroyedFlags[i])
//                 {
//                     Debug.Log($"O marcador '{pair.imageTarget.name}' está no colisor '{pair.colliderUI.name}'!");

//                     // Mudar a cor do colisor para a cor definida no par
//                     pair.colliderUI.GetComponent<Image>().color = pair.collisionColor;

//                     // Excluir filhos diretos do ImageTarget
//                     foreach (Transform child in pair.imageTarget.transform)
//                     {
//                         Destroy(child.gameObject); // Destruir cada filho direto
//                     }

//                     // Marcar como já processado
//                     objectsDestroyedFlags[i] = true;
//                     completedPieces++; // Incrementar o contador de peças concluídas

//                     // Chamar a função para indicar que uma peça foi concluída
//                     OnPieceCompleted();

//                     // Verificar se todas as peças foram concluídas
//                     if (completedPieces == targetColliderPairs.Length)
//                     {
//                         OnAllPiecesCompleted();
//                     }
//                 }
//             }
//         }
//     }

//     // Função chamada sempre que uma peça é concluída
//     void OnPieceCompleted()
//     {
//         Debug.Log("Uma peça foi concluída.");
//         // Adicione sua lógica aqui
//     }

//     // Função chamada quando todas as peças são concluídas
//     void OnAllPiecesCompleted()
//     {
//         Debug.Log("Todas as peças foram concluídas!");
//         // Adicione sua lógica aqui
//     }
// }



// ====================================teste novo ========================

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class MarkerCollisionMapping : MonoBehaviour
// {
//     [System.Serializable]
//     public class TargetColliderPair
//     {
//         public GameObject imageTarget;   // Referência ao marcador (ImageTarget)
//         public RectTransform colliderUI; // Colisor na interface (UI)
//         public Color collisionColor;     // Cor a ser aplicada no colisor ao detectar colisão
//     }

//     public Camera arCamera;                    // ARCamera da cena
//     public TargetColliderPair[] targetColliderPairs; // Lista de pares (ImageTarget -> Collider)
//     public LoadManager loadManager;            // Referência à classe LoadManager

//     private bool[] objectsProcessedFlags;      // Flags para evitar repetição de processamento
//     private int completedPieces = 0;           // Contador de peças processadas

//     void Start()
//     {
//         // Inicializar as flags para cada par e ajustar a cor inicial das imagens
//         objectsProcessedFlags = new bool[targetColliderPairs.Length];
//         foreach (var pair in targetColliderPairs)
//         {
//             if (pair.colliderUI != null)
//             {
//                 // Definir a cor inicial preta com 40% de alpha
//                 pair.colliderUI.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
//             }
//         }
//     }

//     void Update()
//     {
//         for (int i = 0; i < targetColliderPairs.Length; i++)
//         {
//             TargetColliderPair pair = targetColliderPairs[i];

//             if (pair.imageTarget != null && arCamera != null && pair.colliderUI != null)
//             {
//                 // Obter a posição do marcador na tela (2D)
//                 Vector3 markerScreenPosition = arCamera.WorldToScreenPoint(pair.imageTarget.transform.position);

//                 // Verificar se a posição do marcador está dentro do colisor
//                 bool isColliding = RectTransformUtility.RectangleContainsScreenPoint(pair.colliderUI, markerScreenPosition, null);

//                 // Se houver colisão e os filhos ainda não foram processados
//                 if (isColliding && !objectsProcessedFlags[i])
//                 {
//                     Debug.Log($"O marcador '{pair.imageTarget.name}' está no colisor '{pair.colliderUI.name}'!");

//                     // Mudar a cor do colisor para a cor definida no par
//                     pair.colliderUI.GetComponent<Image>().color = pair.collisionColor;

//                     // Tornar os filhos invisíveis (desativar os GameObjects)
//                     foreach (Transform child in pair.imageTarget.transform)
//                     {
//                         child.gameObject.SetActive(false);
//                     }

//                     // Marcar como já processado
//                     objectsProcessedFlags[i] = true;
//                     completedPieces++; // Incrementar o contador de peças concluídas

//                     // Chamar a função para indicar que uma peça foi concluída
//                     OnPieceCompleted();

//                     // Verificar se todas as peças foram concluídas
//                     if (completedPieces == targetColliderPairs.Length)
//                     {
//                         OnAllPiecesCompleted();
//                     }
//                 }
//             }
//         }
//     }

//     // Função chamada sempre que uma peça é concluída
//     void OnPieceCompleted()
//     {
//         Debug.Log("Uma peça foi concluída.");
//         // Adicione lógica extra aqui, se necessário
//     }

//     // Função chamada quando todas as peças são concluídas
//     void OnAllPiecesCompleted()
//     {
//         Debug.Log("Todas as peças foram concluídas!");

//         // Chamar a função LoadAllObjects da classe LoadManager
//         if (loadManager != null)
//         {
//             loadManager.LoadAllObjects();
//         }
//         else
//         {
//             Debug.LogError("LoadManager não está atribuído!");
//         }

//         // Tornar os filhos visíveis novamente
//         foreach (var pair in targetColliderPairs)
//         {
//             foreach (Transform child in pair.imageTarget.transform)
//             {
//                 child.gameObject.SetActive(true);
//             }
//         }

//         // Resetar o contador de peças e flags (opcional, dependendo do comportamento desejado)
//         completedPieces = 0;
//         for (int i = 0; i < objectsProcessedFlags.Length; i++)
//         {
//             objectsProcessedFlags[i] = false;
//         }
//     }
// }


//========================== corrigigo cores ========= (ok)

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class MarkerCollisionMapping : MonoBehaviour
// {
//     [System.Serializable]
//     public class TargetColliderPair
//     {
//         public GameObject imageTarget;   // Referência ao marcador (ImageTarget)
//         public RectTransform colliderUI; // Colisor na interface (UI)
//         public Color collisionColor;     // Cor a ser aplicada no colisor ao detectar colisão
//     }

//     public Camera arCamera;                    // ARCamera da cena
//     public TargetColliderPair[] targetColliderPairs; // Lista de pares (ImageTarget -> Collider)
//     public LoadManager loadManager;            // Referência à classe LoadManager

//     private bool[] objectsProcessedFlags;      // Flags para evitar repetição de processamento
//     private int completedPieces = 0;           // Contador de peças processadas

//     void Start()
//     {
//         // Inicializar as flags para cada par e ajustar a cor inicial das imagens
//         objectsProcessedFlags = new bool[targetColliderPairs.Length];
//         ResetCollidersToInitialState();
//     }

//     void Update()
//     {
//         for (int i = 0; i < targetColliderPairs.Length; i++)
//         {
//             TargetColliderPair pair = targetColliderPairs[i];

//             if (pair.imageTarget != null && arCamera != null && pair.colliderUI != null)
//             {
//                 // Obter a posição do marcador na tela (2D)
//                 Vector3 markerScreenPosition = arCamera.WorldToScreenPoint(pair.imageTarget.transform.position);

//                 // Verificar se a posição do marcador está dentro do colisor
//                 bool isColliding = RectTransformUtility.RectangleContainsScreenPoint(pair.colliderUI, markerScreenPosition, null);

//                 // Se houver colisão e os filhos ainda não foram processados
//                 if (isColliding && !objectsProcessedFlags[i])
//                 {
//                     Debug.Log($"O marcador '{pair.imageTarget.name}' está no colisor '{pair.colliderUI.name}'!");

//                     // Mudar a cor do colisor para a cor definida no par
//                     pair.colliderUI.GetComponent<Image>().color = pair.collisionColor;

//                     // Tornar os filhos invisíveis (desativar os GameObjects)
//                     foreach (Transform child in pair.imageTarget.transform)
//                     {
//                         child.gameObject.SetActive(false);
//                     }

//                     // Marcar como já processado
//                     objectsProcessedFlags[i] = true;
//                     completedPieces++; // Incrementar o contador de peças concluídas

//                     // Chamar a função para indicar que uma peça foi concluída
//                     OnPieceCompleted();

//                     // Verificar se todas as peças foram concluídas
//                     if (completedPieces == targetColliderPairs.Length)
//                     {
//                         OnAllPiecesCompleted();
//                     }
//                 }
//             }
//         }
//     }

//     // Função chamada sempre que uma peça é concluída
//     void OnPieceCompleted()
//     {
//         Debug.Log("Uma peça foi concluída.");
//         // Adicione lógica extra aqui, se necessário
//     }

//     // Função chamada quando todas as peças são concluídas
//     void OnAllPiecesCompleted()
//     {
//         Debug.Log("Todas as peças foram concluídas!");

//         // Chamar a função LoadAllObjects da classe LoadManager
//         if (loadManager != null)
//         {
//             loadManager.LoadAllObjects();
//         }
//         else
//         {
//             Debug.LogError("LoadManager não está atribuído!");
//         }

//         // Tornar os filhos visíveis novamente
//         foreach (var pair in targetColliderPairs)
//         {
//             foreach (Transform child in pair.imageTarget.transform)
//             {
//                 child.gameObject.SetActive(true);
//             }
//         }

//         // Resetar o contador de peças, flags e os colisores
//         completedPieces = 0;
//         for (int i = 0; i < objectsProcessedFlags.Length; i++)
//         {
//             objectsProcessedFlags[i] = false;
//         }

//         ResetCollidersToInitialState();
//     }

//     // Função para resetar os colisores para o estado inicial (cor preta com 40% de transparência)
//     void ResetCollidersToInitialState()
//     {
//         foreach (var pair in targetColliderPairs)
//         {
//             if (pair.colliderUI != null)
//             {
//                 pair.colliderUI.GetComponent<Image>().color = new Color(0, 0, 0, 1f); // Cor preta com 100% alpha
//             }
//         }
//     }
// }




//tentando adicionar o timer ========================================

using UnityEngine;
using UnityEngine.UI;
using TMPro; // Necessário para TextMeshPro

public class MarkerCollisionMapping : MonoBehaviour
{
    [System.Serializable]
    public class TargetColliderPair
    {
        public GameObject imageTarget;   // Referência ao marcador (ImageTarget)
        public RectTransform colliderUI; // Colisor na interface (UI)
        public Color collisionColor;     // Cor a ser aplicada no colisor ao detectar colisão
    }

    public Camera arCamera;                    // ARCamera da cena
    public TargetColliderPair[] targetColliderPairs; // Lista de pares (ImageTarget -> Collider)
    // public Text timerText;                     // Referência ao texto do timer no UI
    public TMP_Text timerText;

    public LoadManager loadManager; 

    private bool[] objectsProcessedFlags;      // Flags para evitar repetição de processamento
    private int completedPieces = 0;           // Contador de peças processadas
    private float elapsedTime = 0f;            // Tempo decorrido

    void Start()
    {
        objectsProcessedFlags = new bool[targetColliderPairs.Length];
        ResetCollidersToInitialState();

        // Inicializar o texto do timer
        if (timerText != null)
        {
            timerText.text = "Time: 0s";
        }
    }

    void Update()
    {
        // Atualizar o timer
        UpdateTimer();

        for (int i = 0; i < targetColliderPairs.Length; i++)
        {
            TargetColliderPair pair = targetColliderPairs[i];

            if (pair.imageTarget != null && arCamera != null && pair.colliderUI != null)
            {
                Vector3 markerScreenPosition = arCamera.WorldToScreenPoint(pair.imageTarget.transform.position);
                bool isColliding = RectTransformUtility.RectangleContainsScreenPoint(pair.colliderUI, markerScreenPosition, null);

                if (isColliding && !objectsProcessedFlags[i])
                {
                    pair.colliderUI.GetComponent<Image>().color = pair.collisionColor;

                    foreach (Transform child in pair.imageTarget.transform)
                    {
                        child.gameObject.SetActive(false);
                    }

                    objectsProcessedFlags[i] = true;
                    completedPieces++;

                    OnPieceCompleted();

                    if (completedPieces == targetColliderPairs.Length)
                    {
                        OnAllPiecesCompleted();
                    }
                }
            }
        }
    }

    void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;

        // Atualizar o texto do timer no formato "Time: Xs"
        if (timerText != null)
        {
            timerText.text = $"Time: {elapsedTime:F1}s";
        }
    }

    void ResetCollidersToInitialState()
    {
        foreach (var pair in targetColliderPairs)
        {
            if (pair.colliderUI != null)
            {
                pair.colliderUI.GetComponent<Image>().color = new Color(0, 0, 0, 1f); // Preto com 100% alpha
            }
        }
    }

    void OnPieceCompleted()
    {
        Debug.Log("Uma peça foi concluída.");
    }

    void OnAllPiecesCompleted()
    {
        Debug.Log("Todas as peças foram concluídas!");

        // Chamar a função LoadAllObjects da classe LoadManager
        if (loadManager != null)
        {
            loadManager.LoadAllObjects();
        }
        else
        {
            Debug.LogError("LoadManager não está atribuído!");
        }


        foreach (var pair in targetColliderPairs)
        {
            foreach (Transform child in pair.imageTarget.transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        completedPieces = 0;
        for (int i = 0; i < objectsProcessedFlags.Length; i++)
        {
            objectsProcessedFlags[i] = false;
        }

        ResetCollidersToInitialState();
        ResetTimer();
    }

    void ResetTimer()
    {
        elapsedTime = 0f;

        // Resetar o texto do timer
        if (timerText != null)
        {
            timerText.text = "Time: 0s";
        }
    }
}

