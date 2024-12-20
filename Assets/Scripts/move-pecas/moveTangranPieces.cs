// using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DragAndSaveMultiple : MonoBehaviour
{
    private Dictionary<string, Vector2> positions = new Dictionary<string, Vector2>();
    private RectTransform rectTransform;

    // Atualiza a posição ao arrastar a imagem
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    // Quando o arraste termina, salva a posição da imagem
    public void OnEndDrag(PointerEventData eventData)
    {
        positions[gameObject.name] = rectTransform.anchoredPosition;
        Debug.Log($"{gameObject.name} - Posição atualizada.");
    }

    // Salvar todas as posições como JSON
    public void SaveAllPositions()
    {
        string json = JsonConvert.SerializeObject(positions, Formatting.Indented);
        Debug.Log(json);

        // Aqui você pode salvar o JSON em um arquivo ou enviar para um servidor
        // Exemplo para salvar em disco:
        // System.IO.File.WriteAllText(Application.persistentDataPath + "/positions.json", json);
    }
}

