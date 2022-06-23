using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStandardData : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private GameData gameData;

	public void Start () {
        player.Hp = 4;
        player.Score = 0;
        player.CurrentLevel = 1;
        gameData.SaveData();
    }
}

