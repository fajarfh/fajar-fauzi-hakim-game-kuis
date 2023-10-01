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
        SceneManager.LoadScene(namaScene);
    }

    private void OnApplicationQuit()
    {
        _initialData.SaatKalah = false;
        _playerProgress.progressData.koin = 0;
    }

}
