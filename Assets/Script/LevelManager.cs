using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private LevelPackKuis[] _soalSoal = new LevelPackKuis[0];

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private UI_Pertanyaan _tempatPertanyaan = null;

    [SerializeField]
    private UI_Jawaban[] _tempatPilihanJawaban = new UI_Jawaban[0];

    private int _indexSoal = -1;
    private int _indexPack = -1;

    private void Start()
    {
        if(!_playerProgress.MuatProgress())
            _playerProgress.SimpanProgress();
        
        NextPack();//Reset LevelPack
        NextLevel();//Reset Soal

    }

    
    //Fungsi untuk berpindah Level Pack
    public void NextPack()
    {

        _indexPack++;
        
        //Jika level Pack sudah habis, kembali ke Level Pack pertama
        if (_indexPack >= _soalSoal.Length)
        {
            _indexPack = 0;
        }

    }

    public void NextLevel()
    {

        _indexSoal++;

        if(_indexSoal >= _soalSoal[_indexPack].BanyakLevel)
        {
            //Jika soal sudah habis, lanjut ke LevelPack berikutnya
            NextPack();
            _indexSoal = 0;
        }

        LevelSoalKuis soal = _soalSoal[_indexPack].AmbilLevelKe(_indexSoal);

        int unicode = 65+_indexPack;
        char character = (char)unicode;
        string packLabel = character.ToString();

        _tempatPertanyaan.SetPertanyaan($"Level {packLabel}-{_indexSoal+1}", soal.pertanyaan, soal.hint);

        for(int i=0; i< _tempatPilihanJawaban.Length; i++)
        {
            UI_Jawaban poin = _tempatPilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }

    }
}
