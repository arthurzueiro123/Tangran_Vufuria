using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SaveAndLoadManager : MonoBehaviour
{
    [Tooltip("Lista de objetos que possuem o script DragAndSave")]
    public List<GameObject> objectsToSave;

    private string filePath;

    private void Awake()
    {
        // Define o caminho do arquivo JSON (pode ser personalizado)
        filePath = Path.Combine(Application.persistentDataPath, "saved_positions.json");
    }

    // Salva os dados de todos os objetos da lista em um arquivo JSON
    public void SaveAllObjects()
    {
        var objectsData = new List<ObjectData>();

        foreach (GameObject obj in objectsToSave)
        {
            if (obj.TryGetComponent<DragAndSave>(out DragAndSave dragAndSave))
            {
                (Vector2 position, float rotation) data = dragAndSave.GetPositionAndRotation();

                objectsData.Add(new ObjectData
                {
                    name = obj.name,
                    position = new Vector2(data.position.x, data.position.y),
                    rotation = data.rotation
                });
            }
        }

        string json = JsonConvert.SerializeObject(objectsData, Formatting.Indented);
        File.WriteAllText(filePath, json);

        Debug.Log($"Dados salvos em {filePath}");
    }

    // Carrega os dados do arquivo JSON e reposiciona os objetos na cena
    public void LoadAllObjects()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError($"Arquivo {filePath} não encontrado!");
            return;
        }

        string json = File.ReadAllText(filePath);
        var objectsData = JsonConvert.DeserializeObject<List<ObjectData>>(json);

        foreach (ObjectData data in objectsData)
        {
            GameObject obj = objectsToSave.Find(o => o.name == data.name);
            if (obj != null && obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
            {
                rectTransform.anchoredPosition = data.position;
                rectTransform.rotation = Quaternion.Euler(0, 0, data.rotation);

                Debug.Log($"Objeto {data.name} reposicionado para {data.position} com rotação {data.rotation}");
            }
        }
    }

    // Classe para armazenar os dados de posição e rotação
    private class ObjectData
    {
        public string name;
        public Vector2 position;
        public float rotation;
    }
}
