using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {

        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        //   
        //   

    }
}
