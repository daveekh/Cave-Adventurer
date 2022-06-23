using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;

    public void MenuStart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MenuExit()
    {
        //PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void PauseBack()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void PauseExit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
        //PlayerPrefs.DeleteAll();
    }

}
