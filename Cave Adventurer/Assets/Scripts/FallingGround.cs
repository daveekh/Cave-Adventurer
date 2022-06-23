using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingGround : MonoBehaviour {

    [SerializeField] private GameObject fallingGround;
    [SerializeField] private Animator anim;
    [SerializeField] private Player player;
    private float timeFall1;
    private float timeFall2;
    private float timeFall3;

    void OnCollisionEnter2D(Collision2D col)
    {
        timeFall1 = Time.time;
        // Debug.Log("OnCollisionEnter: " + timeFall1);
        StartCoroutine(WaitForAction());
        
    }
	
    IEnumerator WaitForAction()
    {
        yield return new WaitForSeconds(1.0f);
        // anim.SetTrigger("Falling Ground");
        timeFall2 = Time.time;
        // Debug.Log("Falling Ground: " + timeFall2);

        yield return new WaitForSeconds(0.5f);
        Destroy(fallingGround);

        if(timeFall3 > timeFall2)
        {
            player.Hp -= 2;
            player.CheckDeath();

        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        timeFall3 = Time.time;
        // Debug.Log("OnCollisionExit: " + timeFall3);
    }

	// Update is called once per frame
	void Update () {

	}

    void Start ()
    {
    }
}
