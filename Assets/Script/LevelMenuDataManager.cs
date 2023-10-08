using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private TextMeshProUGUI _tempatKoin = null;

    [SerializeField]
    private UI_LevelPackList _levelPackList = null;

    [Space, SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    void Start()
    {

        if (!_playerProgress.MuatProgress())
            _playerProgress.SimpanProgress();

        _levelPackList.LoadLevelPack(_levelPacks, _playerProgress.progressData);

        _tempatKoin.text = $"{_playerProgress.progressData.koin}";

        AudioManager.instance.PlayBGM(0);
    }

}
