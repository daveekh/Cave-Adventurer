using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

    [SerializeField] Player player;
    [SerializeField] GameObject key;

    void OnTriggerEnter2D(Collider2D col)
    {
        player.Keys += 1;
        Destroy(this.key);
    }

}
