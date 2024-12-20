// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MoveImage : MonoBehaviour
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

// tav ok=======================================================================================

// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
// using System.Collections.Generic;
// using Newtonsoft.Json;

// public class DragAndSave : MonoBehaviour, IDragHandler, IEndDragHandler
// {
//     private RectTransform rectTransform;

//     private void Awake()
//     {
//         rectTransform = GetComponent<RectTransform>();
//     }

//     // Permite arrastar o objeto
//     public void OnDrag(PointerEventData eventData)
//     {
//         rectTransform.anchoredPosition += eventData.delta;
//     }

//     // Após terminar o arraste, salva as coordenadas
//     public void OnEndDrag(PointerEventData eventData)
//     {
//         Debug.Log($"Imagem {name} - Posição: {rectTransform.anchoredPosition}");
//         SavePosition();
//     }

//     // Salvar posição como JSON
//     private void SavePosition()
//     {
//         // Cria um objeto para armazenar as coordenadas
//         var data = new
//         {
//             name = gameObject.name,
//             position = new
//             {
//                 x = rectTransform.anchoredPosition.x,
//                 y = rectTransform.anchoredPosition.y
//             }
//         };

//         // Converte para JSON e exibe no console
//         string json = JsonConvert.SerializeObject(data, Formatting.Indented);
//         Debug.Log(json);

//         // Aqui você pode salvar o JSON onde desejar
//         // (por exemplo, em um arquivo ou enviar para um servidor)
//     }
// }

//primeiro rotate =================================================================

// using UnityEngine;
// using UnityEngine.EventSystems;
// using Newtonsoft.Json;

// public class DragAndSave : MonoBehaviour, IDragHandler, IEndDragHandler
// {
//     private RectTransform rectTransform;
//     private bool isDragging = false; // Controla se o objeto está sendo arrastado

//     private void Awake()
//     {
//         rectTransform = GetComponent<RectTransform>();
//     }

//     private void Update()
//     {
//         // Verifica se a tecla R foi pressionada e o objeto está sendo arrastado
//         if (isDragging && Input.GetKeyDown(KeyCode.R))
//         {
//             RotateObject();
//         }
//     }

//     // Permite arrastar o objeto
//     public void OnDrag(PointerEventData eventData)
//     {
//         rectTransform.anchoredPosition += eventData.delta;
//         isDragging = true; // Marca que o objeto está sendo arrastado
//     }

//     // Após terminar o arraste, salva as coordenadas
//     public void OnEndDrag(PointerEventData eventData)
//     {
//         isDragging = false; // Reseta o estado de arraste
//         Debug.Log($"Imagem {name} - Posição: {rectTransform.anchoredPosition}");
//         SavePosition();
//     }

//     // Rotaciona o objeto em 45 graus
//     private void RotateObject()
//     {
//         rectTransform.Rotate(0, 0, 45); // Aplica a rotação no eixo Z
//         Debug.Log($"Imagem {name} - Rotacionada para {rectTransform.eulerAngles.z} graus");
//     }

//     // Salvar posição como JSON
//     private void SavePosition()
//     {
//         // Cria um objeto para armazenar as coordenadas
//         var data = new
//         {
//             name = gameObject.name,
//             position = new
//             {
//                 x = rectTransform.anchoredPosition.x,
//                 y = rectTransform.anchoredPosition.y
//             }
//         };

//         // Converte para JSON e exibe no console
//         string json = JsonConvert.SerializeObject(data, Formatting.Indented);
//         Debug.Log(json);

//         // Aqui você pode salvar o JSON onde desejar
//         // (por exemplo, em um arquivo ou enviar para um servidor)
//     }
// }



//save and export funcs

using UnityEngine;
using UnityEngine.EventSystems;
using Newtonsoft.Json;

public class DragAndSave : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private bool isDragging = false; // Controla se o objeto está sendo arrastado

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Verifica se a tecla R foi pressionada e o objeto está sendo arrastado
        if (isDragging && Input.GetKeyDown(KeyCode.R))
        {
            RotateObject();
        }
    }

    // Permite arrastar o objeto
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        isDragging = true; // Marca que o objeto está sendo arrastado
    }

    // Após terminar o arraste, salva as coordenadas e a rotação
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false; // Reseta o estado de arraste
        Debug.Log($"Imagem {name} - Posição: {rectTransform.anchoredPosition}, Rotação: {rectTransform.eulerAngles.z}");
        SavePositionAndRotation();
    }

    // Rotaciona o objeto em 45 graus
    private void RotateObject()
    {
        rectTransform.Rotate(0, 0, 45); // Aplica a rotação no eixo Z
        Debug.Log($"Imagem {name} - Rotacionada para {rectTransform.eulerAngles.z} graus");
    }

    // Salvar posição e rotação como JSON
    private void SavePositionAndRotation()
    {
        // Cria um objeto para armazenar as coordenadas e rotação
        var data = new
        {
            name = gameObject.name,
            position = new
            {
                x = rectTransform.anchoredPosition.x,
                y = rectTransform.anchoredPosition.y
            },
            rotation = rectTransform.eulerAngles.z
        };

        // Converte para JSON e exibe no console
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        Debug.Log(json);

        // Aqui você pode salvar o JSON onde desejar
        // (por exemplo, em um arquivo ou enviar para um servidor)
    }

    // Retorna as coordenadas e rotação do objeto
    public (Vector2 position, float rotation) GetPositionAndRotation()
    {
        Vector2 position = rectTransform.anchoredPosition;
        float rotation = rectTransform.eulerAngles.z;
        return (position, rotation);
    }
}
