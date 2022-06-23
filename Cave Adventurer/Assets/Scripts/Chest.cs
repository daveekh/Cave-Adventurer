using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    [SerializeField] private GameObject winPanel;

    void OnTriggerEnter2D(Collider2D col)
    {
        Time.timeScale = 0.0f;
        winPanel.SetActive(true);
    }


}
