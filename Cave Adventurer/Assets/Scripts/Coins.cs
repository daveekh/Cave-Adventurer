using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coins : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Animator animation;
    [SerializeField] private GameObject coin;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip coinSound;

    void Start()
    {
        audioSource.clip = coinSound;
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(5f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioSource.Play();
            // StartCoroutine(WaitForAnim());
            // animation.SetTrigger("Gathering");
            player.Score += 5;
            Destroy(coin);
        }
    }


}



