// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class MirrorCamera : MonoBehaviour
// // {
// //     // Start is called before the first frame update
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// // }


// using UnityEngine;
// using Vuforia;

// public class MirrorVuforiaCamera : MonoBehaviour
// {
//     void Start()
//     {
//         // Obter o objeto responsável pelo fundo da câmera
//         var backgroundPlane = FindObjectOfType<BackgroundPlaneBehaviour>();
//         if (backgroundPlane != null)
//         {
//             // Inverter o eixo Y para espelhar
//             backgroundPlane.transform.localScale = new Vector3(1, -1, 1);
//             Debug.Log("Plano de fundo da câmera espelhado no eixo Y.");
//         }
//         else
//         {
//             Debug.LogWarning("Plano de fundo da câmera do Vuforia não encontrado.");
//         }
//     }
// }
