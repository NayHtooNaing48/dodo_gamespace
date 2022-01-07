using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public void loadS(int scene) {

        SceneManager.LoadScene(scene);

    }

    private void Awake()
    {
        Screen.SetResolution(1280,720,true);
        Time.timeScale = 1;
    }

}