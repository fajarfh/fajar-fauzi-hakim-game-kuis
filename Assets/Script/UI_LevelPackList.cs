using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private InitialDataGameplay _initialData = null;


    [SerializeField]
    private UI_LevelKuisList _levelList = null;
    
    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack = null;

    [SerializeField]
    private RectTransform _content = null;

    [Space, SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        loadLevelPack();

        if (_initialData.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(_initialData.levelPack);
        }


        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        _levelList.gameObject.SetActive(true);
        _levelList.unloadLevelPack(levelPack);
        gameObject.SetActive(false);

        _initialData.levelPack = levelPack;
    }

    private void loadLevelPack()
    {
        foreach(var lp in _levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

}
