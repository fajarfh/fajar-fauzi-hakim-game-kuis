using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField]
    private InitialDataGameplay _initialData = null;


    [SerializeField]
    private UI_OpsiLevelKuis _tombolLevel = null;

    [SerializeField]
    private RectTransform _content = null;

    [Space, SerializeField]
    private LevelPackKuis _levelPack = null;

    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _gameplayScene = string.Empty;

    [SerializeField]
    private TextMeshProUGUI _levelPackTitle = null;


    private void Start()
    {
        //Untuk tes dengan level pack sampel
        //    if(_levelPack != null)
        //        unloadLevelPack(_levelPack);

        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        _initialData.levelIndex = index;
        _gameSceneManager.BukaScene(_gameplayScene);
    }

    private void OnDestroy()
    {
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }

    public void unloadLevelPack(LevelPackKuis levelPack)
    {

        HapusIsiKonten();

        _levelPack = levelPack;
        _levelPackTitle.text = levelPack.name;

        for(int i = 0; i <_levelPack.BanyakLevel; i++)
        {
            var t = Instantiate(_tombolLevel);

            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for(int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
