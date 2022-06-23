using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    // skrypt przechowujący właściwości gracza

    private int hp = 4;
    public int Hp { get { return this.hp; } set { this.hp = value; } }

    private int score = 0;
    public int Score { get { return this.score; } set { this.score = value; } }

    private int keys = 0;
    public int Keys { get { return this.keys; } set { this.keys = value; } }

    private int currentLevel = 1;
    public int CurrentLevel { get { return this.currentLevel; } set { this.currentLevel = value; } }

    private bool flipRight = true;
    public bool FlipRight { get { return this.flipRight; } set { this.flipRight = value; } }

    [SerializeField] private GameObject panel;
    [SerializeField] private TilemapCollider2D spikesAndFireCollider;
    [SerializeField] private GameObject blood;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPoint;

    [SerializeField] private GameData gameData;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animation;
    [SerializeField] private Text scoreUI;
    [SerializeField] private Text keysUI;
    [SerializeField] private Text hpUI;

    [SerializeField] private SpriteRenderer playerSR;



    public void Flip()
    {
        if(playerSR.flipX == true)
        {
            flipRight = true;
        }

        if(playerSR.flipX == false)
        {
            flipRight = false;
        }
    }

    public void TurnOffCollisions()
    {
        spikesAndFireCollider.enabled = false;
    }

    public void CheckDeath()
    {

        if (hp <= 0)
        {
            animation.SetBool("checkDeath", true);
            TurnOffCollisions();
            playerMovement.enabled = false;
            Instantiate(blood, transform.position, transform.rotation);
            panel.SetActive(true);
        }

    }

    void Awake()
    {

    }

    void Start()
    {
        if (gameData != null)
        {
            gameData.LoadData();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = bulletPoint.transform.position;
                bullet.transform.rotation = bulletPoint.transform.rotation;
                bullet.SetActive(true);
            }
        }

        if (scoreUI != null && keysUI != null && hpUI != null)
        {
            scoreUI.text = score.ToString();
            keysUI.text = keys.ToString();
            hpUI.text = hp.ToString();
        }

        Flip();

    }
}

