using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    [SerializeField] private Player player;
    
    public void SaveData()
    {
        PlayerPrefs.SetInt("HP", player.Hp);
        PlayerPrefs.SetInt("Score", player.Score);
        PlayerPrefs.SetInt("CurrentLevel", player.CurrentLevel);
    }

    public void LoadData()
    {
        player.Hp = PlayerPrefs.GetInt("HP");
        player.Score = PlayerPrefs.GetInt("Score");
        player.CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }
}
