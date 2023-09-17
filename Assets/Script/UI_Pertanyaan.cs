using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _tempatTeks = null;

    [SerializeField]
    private Image _tempatGambar = null;

    [SerializeField]
    private TextMeshProUGUI _tempatJudulLevel = null;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Isi tempatTeks adalah:");
        //Debug.Log(_tempatTeks.text);
    }

    public void SetPertanyaan(string teksJudulLevel, string teksPertanyaan, Sprite gambarHint)
    {
        _tempatJudulLevel.text = teksJudulLevel;
        _tempatTeks.text = teksPertanyaan;
        _tempatGambar.sprite = gambarHint;
    }
    
}
