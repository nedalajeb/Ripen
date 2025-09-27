using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject EndPanel;

    // Start is called before the first frame update
    public void Quit()
    {
        EndPanel.SetActive(false);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //   
        //   

    }
}
