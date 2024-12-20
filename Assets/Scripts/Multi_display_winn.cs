using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multi_display_winn : MonoBehaviour
{
    public TextMeshProUGUI winnDisp;

    // Start is called before the first frame update
    void Start()
    {
        string winner = PlayerPrefs.GetString("winner", "desconhecido");

        winnDisp.text = $"Vencedor: {winner}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
