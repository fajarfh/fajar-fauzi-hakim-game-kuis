using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private InitialDataGameplay _initialData = null;

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private UI_LevelKuisList _levelList = null;
    
    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private Animator _animator = null;

    private void Start()
    {
        //LoadLevelPack();

        if (_initialData.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(null, _initialData.levelPack, false);
        }

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {

        if (terkunci) return;

        //_levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack, _playerProgress.progressData);
        //gameObject.SetActive(false);
        
        //Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName("EMPTY"));
        if (_initialData.SaatKalah)
        {
            _animator.SetTrigger("KePack");
        }
        else
        {
            _animator.SetTrigger("KeLevels");
        }
            
        //Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName("Transisi_Ke_Menu_Level_Packs"));

        _initialData.levelPack = levelPack;
    }

    public void LoadLevelPack(LevelPackKuis[] levelPacks, PlayerProgress.MainData playerData)
    {
        foreach(var lp in levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            if (!playerData.progressLevel.ContainsKey(lp.name))
                t.KunciLevelPack();
        }
    }

}
