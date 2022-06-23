using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Doors : MonoBehaviour {

    [SerializeField] private SpriteRenderer door;
    [SerializeField] private Sprite doorOpened;
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private GameObject tarcza;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(tarcza);
            door.sprite = doorOpened;
            doorCollider.enabled = false;
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.K))
        {
            door.sprite = doorOpened;
            doorCollider.enabled = false;
        }


	}
}
