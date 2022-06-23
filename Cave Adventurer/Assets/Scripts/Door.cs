using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    [SerializeField] private Sprite doorOpened;
    [SerializeField] private SpriteRenderer door;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private Player player;
    [SerializeField] private GameData gameData;



    void Update()
    {
        if (player.Keys == 3)
        {
            door.sprite = doorOpened;
            collider.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.K))        // test
        {
            player.Keys = 3;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Current Level Before Change Scene: " + player.CurrentLevel);

            player.CurrentLevel += 1;
            gameData.SaveData();
            SceneManager.LoadScene("Level" + player.CurrentLevel);

            Debug.Log("Current Level After Change Scene: " + player.CurrentLevel);
        }
    }


}
