using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Jawaban : MonoBehaviour
{
    public static event System.Action<string, bool> EventJawabSoal;

    //[SerializeField]
    //private UI_PesanLevel _tempatPesan = null;

    [SerializeField]
    private TextMeshProUGUI _teksJawaban = null;

    [SerializeField]
    private bool _adalahBenar = false;

    public void PilihJawaban()
    {
        //Debug.Log($"Jawaban kamu adalah {_teksJawaban.text} ({_adalahBenar})");
        //_tempatPesan.Pesan = $"Jawaban kamu adalah {_teksJawaban.text} ({_adalahBenar})";
        EventJawabSoal?.Invoke(_teksJawaban.text, _adalahBenar);
    }

    public void SetJawaban(string teksJawaban, bool adalahBenar)
    {
        _teksJawaban.text = teksJawaban;
        _adalahBenar = adalahBenar;
    }
}
