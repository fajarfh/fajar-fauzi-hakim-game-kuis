using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PesanLevel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tempatPesan = null;

    [SerializeField]
    private GameObject _opsiMenang = null;

    [SerializeField]
    private GameObject _opsiKalah = null;

    [SerializeField]
    private Animator _animator = null;

    [SerializeField]
    private PemanggilSuara _panggilSuara = null;

    [SerializeField]
    private AudioClip _suaraKebenaran = null;

    [SerializeField]
    private AudioClip _suaraKesalahan = null;

    public string Pesan
    {
        get => _tempatPesan.text;
        set => _tempatPesan.text = value;
    }

    public void Awake()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);

        UI_Timer.EventWaktuHabis += UI_Timer_EventWaktuHabis;
        UI_Jawaban.EventJawabSoal += UI_Jawaban_EventJawabSoal;

    }

    private void UI_Jawaban_EventJawabSoal(string jawabanTeks, bool adalahBenar)
    {
        Pesan = $"Jawaban kamu adalah {jawabanTeks} ({adalahBenar})";
        gameObject.SetActive(true);

        if (adalahBenar)
        {
            _opsiMenang.SetActive(true);
            _opsiKalah.SetActive(false);
            
            _animator.SetTrigger("KeBetulan");
            _panggilSuara.PanggilSuara(_suaraKebenaran);
            //Debug.Log("Ketrigger Betulan");
        }
        else
        {
            _opsiMenang.SetActive(false);
            _opsiKalah.SetActive(true);
            _animator.SetTrigger("KeSalahan");
            _panggilSuara.PanggilSuara(_suaraKesalahan);
            //Debug.Log("Ketrigger Salahanan");
        }


    }

    private void OnDestroy()
    {
        UI_Timer.EventWaktuHabis -= UI_Timer_EventWaktuHabis;
        UI_Jawaban.EventJawabSoal -= UI_Jawaban_EventJawabSoal;
    }

    private void UI_Timer_EventWaktuHabis()
    {
        Pesan = "Waktu sudah habis yattsss UwU!";
        gameObject.SetActive(true);

        _opsiMenang.SetActive(false);
        _opsiKalah.SetActive(true);
    }
}
