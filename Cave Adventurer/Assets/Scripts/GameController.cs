using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private float levelTime;
    [SerializeField] private Text levelTimeUI;
    [SerializeField] private GameObject timeGhost;

    void Update()
    {
        levelTimeUI.text = levelTime.ToString();
        levelTime -= Time.deltaTime;

        if (levelTime <= 0)
        {
            levelTime = 0;
        }

        if (levelTime == 0)
        {
            if (timeGhost != null)
            {
                timeGhost.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);
        }
    }

    void Start()
    {
    }

}

