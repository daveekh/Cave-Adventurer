using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private GameObject bullet;
    [SerializeField] private Rigidbody2D bulletRb;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private BoxCollider2D bulletCol;
    [SerializeField] private BoxCollider2D playerCol;
    [SerializeField] private CapsuleCollider2D coinCol;

    private GameObject player;
    private SpriteRenderer playerSR;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerSR = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerSR.flipX == false)
        {
            bulletRb.velocity = new Vector2(bulletSpeed * bullet.transform.localScale.x, 0);
        }

        if (playerSR.flipX == true)
        {
            bulletRb.velocity = new Vector2(bulletSpeed * bullet.transform.localScale.x, 0);
            bulletRb.velocity = -bulletRb.velocity;
        }

        StartCoroutine(Wait2Sec());
    }

    IEnumerator Wait2Sec()
    {
        yield return new WaitForSeconds(1.5f);
        bullet.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(bulletCol, playerCol);
        }

        else if (col.gameObject.tag == "Coin")
        {
            Physics2D.IgnoreCollision(bulletCol, coinCol);
        }

        else
        {
            bullet.SetActive(false);
        }
    }
    
}
