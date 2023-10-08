using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeReference]
    private InitialDataGameplay _initialData = null;

    [SerializeReference]
    private PlayerProgress _playerProgress = null;


    public void BukaScene(string namaScene)
    {
        //string cekScene = SceneManager.GetActiveScene().name;
        //Debug.Log(cekScene);
        //SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName(namaScene));
        _playerProgress.SimpanProgress();
        SceneManager.LoadScene(namaScene);
    }

    private void OnApplicationQuit()
    {
        _initialData.SaatKalah = false;
        _initialData.levelIndex = 0;
        _playerProgress.progressData.koin = 0;
    }

}
