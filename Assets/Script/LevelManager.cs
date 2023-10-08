using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    //private LevelPackKuis[] _soalSoal = new LevelPackKuis[0];
    private LevelPackKuis _soalSoal = null;

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private UI_Pertanyaan _tempatPertanyaan = null;

    [SerializeField]
    private UI_Jawaban[] _tempatPilihanJawaban = new UI_Jawaban[0];

    [SerializeField]
    private GameSceneManager _sceneManager = null;

    [SerializeField]
    private string _namaScenePilihMenu = string.Empty;

    [SerializeField]
    private InitialDataGameplay _initialData = null;

    private int _indexSoal = -1;
    //private int _indexPack = -1;

    private void Start()
    {
        //if(!_playerProgress.MuatProgress())
        //    _playerProgress.SimpanProgress();

        //NextPack();//Reset LevelPack

        _soalSoal = _initialData.levelPack;
        _indexSoal = _initialData.levelIndex - 1;

        NextLevel();//Reset Soal

        UI_Jawaban.EventJawabSoal += UI_Jawaban_EventJawabSoal;

        AudioManager.instance.PlayBGM(1);

    }

    private void OnDestroy()
    {
        UI_Jawaban.EventJawabSoal -= UI_Jawaban_EventJawabSoal;
    }

    private void UI_Jawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        if (!adalahBenar) return;

        string namaLevelPack = _soalSoal.name;
        int levelTerakhir = _playerProgress.progressData.progressLevel[namaLevelPack];

        if(_indexSoal + 1 > levelTerakhir)
        {
        
            _playerProgress.progressData.koin += 20;

            if (!_playerProgress.progressData.progressLevel.ContainsKey(_soalSoal.name))
            {
                _playerProgress.progressData.progressLevel.Add(_soalSoal.name, _indexSoal+1);
            }
            else
            {
                _playerProgress.progressData.progressLevel[_soalSoal.name] = _indexSoal+1;
            }

                
        }
    }


    //Fungsi untuk berpindah Level Pack
    //public void NextPack()
    //{

    //    _indexPack++;

    //    //Jika level Pack sudah habis, kembali ke Level Pack pertama
    //    if (_indexPack >= _soalSoal.Length)
    //    {
    //        _indexPack = 0;
    //    }

    //}

    public void NextLevel()
    {

        _indexSoal++;

        if(_indexSoal >= _soalSoal.BanyakLevel)
        {
            //Jika soal sudah habis, lanjut ke LevelPack berikutnya
            //NextPack();

            _indexSoal = 0;
            _initialData.SaatKalah = false;
            //Jika soal sudah habis, pindah ke scene _namaScenePilihMenu
            _playerProgress.SimpanProgress();
            _sceneManager.BukaScene(_namaScenePilihMenu);
            return;

        }

        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);

        //int unicode = 65+_indexPack;
        //char character = (char)unicode;
        //string packLabel = character.ToString();

        _tempatPertanyaan.SetPertanyaan($"{_soalSoal.name}-{_indexSoal+1}", soal.pertanyaan, soal.hint);

        for(int i=0; i< _tempatPilihanJawaban.Length; i++)
        {
            UI_Jawaban poin = _tempatPilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }

    }
}
