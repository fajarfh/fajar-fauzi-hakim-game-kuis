using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelKuis : MonoBehaviour
{

    public static event System.Action<int> EventSaatKlik;

    [SerializeField]
    private TextMeshProUGUI _levelName = null;

    [SerializeField]
    private LevelSoalKuis _levelKuis = null;

    [SerializeField]
    private Button _tombolLevel = null;

    private void Start()
    {
        if (_levelKuis != null)
            SetLevelKuis(_levelKuis, _levelKuis.levelPackIndex);

        _tombolLevel.onClick.AddListener(SaatClick);

    }

    private void OnDestroy()
    {
        _tombolLevel.onClick.RemoveListener(SaatClick);
    }

    public void SetLevelKuis(LevelSoalKuis levelKuis, int index)
    {
        _levelName.text = levelKuis.name;
        _levelKuis = levelKuis;

        _levelKuis.levelPackIndex = index;
    }

    private void SaatClick()
    {
        //Debug.Log("TOT");
        EventSaatKlik?.Invoke(_levelKuis.levelPackIndex);
    }

}
