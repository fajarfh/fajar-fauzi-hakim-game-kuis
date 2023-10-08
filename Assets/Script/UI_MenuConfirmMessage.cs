using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_MenuConfirmMessage : MonoBehaviour
{
    [Space, Header("Isi Pesan")]
    [SerializeField]
    private TextMeshProUGUI _tempatPesan = null;
    
    [SerializeField]
    private string _isiPesanCukup = string.Empty;
    
    [SerializeField]
    private string _isiPesanTakCukup = string.Empty;
    
    [SerializeField]
    private GameObject _pesanCukupKoin = null;

    [SerializeField]
    private GameObject _pesanTakCukupKoin = null;

    [Space, Header("Lainnya")]
    [SerializeField]
    private PlayerProgress _playerData = null;
    [SerializeField]
    private TextMeshProUGUI _tempatKoin = null;

    private UI_OpsiLevelPack _tombolLevelPack = null;

    private LevelPackKuis _levelPack = null;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {
        if (!terkunci) return;

        gameObject.SetActive(true);

        if(_playerData.progressData.koin < levelPack.Harga)
        {
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            _tempatPesan.text =_isiPesanTakCukup;
        }
        else
        {
            _pesanCukupKoin.SetActive(true);
            _pesanTakCukupKoin.SetActive(false);
            _tempatPesan.text = $"{_isiPesanCukup} {levelPack.name}?";
        }

        _tombolLevelPack = tombolLevelPack;
        _levelPack = levelPack;

        
    }

    public void BukaLevel()
    {
        _playerData.progressData.koin -= _levelPack.Harga;
        _playerData.progressData.progressLevel[_levelPack.name] = 0;

        _tempatKoin.text = $"{_playerData.progressData.koin}";

        _playerData.SimpanProgress();

        _tombolLevelPack.BukaLevelPack();

    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }
}
