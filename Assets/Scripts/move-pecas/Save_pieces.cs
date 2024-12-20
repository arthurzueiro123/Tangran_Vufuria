// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Save_pieces : MonoBehaviour
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


// using UnityEngine;
// using System.Collections.Generic;
// using System.IO;
// using Newtonsoft.Json;

// public class SaveManager : MonoBehaviour
// {
//     [Tooltip("Lista de objetos que possuem o script DragAndSave")]
//     public List<GameObject> objectsToSave;

//     [Tooltip("Caminho do arquivo JSON")]
//     public string customFilePath = "";

//     private string filePath;

//     private void Start()
//     {
//         // Define o caminho do arquivo se não for configurado manualmente
//         filePath = string.IsNullOrEmpty(customFilePath)
//             ? Path.Combine(Application.persistentDataPath, "saved_positions.json")
//             : customFilePath;

//         Debug.Log($"Arquivo de salvamento: {filePath}");
//     }

//     private void Update()
//     {
//         // Salva os dados ao pressionar a tecla S
//         if (Input.GetKeyDown(KeyCode.S))
//         {
//             SaveAllObjects();
//         }
//     }

//     // Salva os dados de todos os objetos em um arquivo JSON
//     public void SaveAllObjects()
//     {
//         var objectsData = new List<ObjectData>();

//         foreach (GameObject obj in objectsToSave)
//         {
//             if (obj.TryGetComponent<DragAndSave>(out DragAndSave dragAndSave))
//             {
//                 (Vector2 position, float rotation) data = dragAndSave.GetPositionAndRotation();

//                 objectsData.Add(new ObjectData
//                 {
//                     name = obj.name,
//                     position = new Vector2(data.position.x, data.position.y),
//                     rotation = data.rotation
//                 });
//             }
//         }

//         string json = JsonConvert.SerializeObject(objectsData, Formatting.Indented);
//         File.WriteAllText(filePath, json);

//         Debug.Log($"Dados salvos em {filePath}");
//     }

//     // Classe para armazenar os dados de posição e rotação
    
//     private class ObjectData
//     {
//         public string name;
//         public Vector2 position;
//         public float rotation;
//     }
// }





using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    [Tooltip("Lista de objetos que possuem o script DragAndSave")]
    public List<GameObject> objectsToSave;

    [Tooltip("Caminho do arquivo JSON")]
    public string customFilePath = "";

    private string filePath;

    private void Start()
    {
        // Define o caminho do arquivo se não for configurado manualmente
        filePath = string.IsNullOrEmpty(customFilePath)
            ? Path.Combine(Application.persistentDataPath, "saved_positions.json")
            : customFilePath;

        Debug.Log($"Arquivo de salvamento: {filePath}");
    }

    private void Update()
    {
        // Salva os dados ao pressionar a tecla S
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveAllObjects();
        }
    }

    // Salva os dados de todos os objetos em um arquivo JSON
    public void SaveAllObjects()
    {
        var objectsData = new List<ObjectData>();

        foreach (GameObject obj in objectsToSave)
        {
            if (obj.TryGetComponent<DragAndSave>(out DragAndSave dragAndSave))
            {
                // Obtém os dados de posição e rotação
                (Vector2 position, float rotation) data = dragAndSave.GetPositionAndRotation();

                // Adiciona os dados à lista
                objectsData.Add(new ObjectData
                {
                    name = obj.name,
                    position = new Vector2(data.position.x, data.position.y),
                    rotation = data.rotation
                });
            }
        }

        // Serializa a lista de dados para JSON
        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Evita referências circulares
        };

        string json = JsonConvert.SerializeObject(objectsData, Formatting.Indented, settings);
        File.WriteAllText(filePath, json);

        Debug.Log($"Dados salvos em {filePath}");
    }

    // Classe para armazenar os dados de posição e rotação
    private class ObjectData
    {
        public string name;
        public Vector2 position;
        public float rotation;
    }
}

