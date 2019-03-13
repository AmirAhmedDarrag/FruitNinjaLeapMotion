using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadS : MonoBehaviour {

    public void LoadScenes(string sceneLoaded)
    {

        SceneManager.LoadScene(sceneLoaded);
    }
}
