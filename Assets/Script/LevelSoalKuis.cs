using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Soal Baru",
    menuName = "Game Kuis/Level Soal Kuis")]


public class LevelSoalKuis : ScriptableObject
{
    public Sprite hint = null;
    public string pertanyaan = string.Empty;
    public int levelPackIndex = 0;
    
    [System.Serializable]
    public struct OpsiJawaban
    {
        public string jawabanTeks;
        public bool adalahBenar;
    }

    public OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];

    
}
