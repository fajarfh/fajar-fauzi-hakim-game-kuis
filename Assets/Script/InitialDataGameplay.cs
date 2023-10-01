using UnityEngine;

[CreateAssetMenu(
    fileName = "Initial Data Gameplay",
    menuName = "Game Kuis/Initial Data Gameplay")]

public class InitialDataGameplay : ScriptableObject
{
    public LevelPackKuis levelPack = null;
    public int levelIndex = 0;

    [SerializeField]
    private bool _saatKalah = false;

    public bool SaatKalah
    {
        get => _saatKalah;
        set => _saatKalah = value;
    }

}
