// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ChangeSpriteColor : MonoBehaviour
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
// using UnityEngine.UI;

// public class ChangeSpriteColor : MonoBehaviour
// {
//     public Image spriteImage; // Arraste seu Image Sprite aqui no Inspector.
//     public Color newColor = Color.red; // Cor que você quer adicionar sobre o sprite.

//     void Start()
//     {
//         if (spriteImage != null)
//         {
//             spriteImage.color = newColor;
//         }
//         else
//         {
//             Debug.LogError("Por favor, atribua um Image ao script no Inspector!");
//         }
//     }
// }



using UnityEngine;
using UnityEngine.UI;

public class DynamicSpriteColorChange : MonoBehaviour
{
    public Image spriteImage; // Referência ao Image.
    public Button changeColorButton; // Referência ao botão.

    void Start()
    {
        // // Verifique se as referências estão atribuídas.
        // if (spriteImage != null && changeColorButton != null)
        // {
        //     changeColorButton.onClick.AddListener(ChangeColor); // Associe o evento.
        // }
        // else
        // {
        //     Debug.LogError("Atribua o botão e o sprite no Inspector!");
        // }
        ChangeColor();
    }

    void ChangeColor()
    {
        spriteImage.color = new Color(Random.value, Random.value, Random.value); // Cor aleatória.
    }
}
