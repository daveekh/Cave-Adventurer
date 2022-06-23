using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour {

    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 2f;

    [SerializeField] private Player player;
    [SerializeField] private GameObject monster;


    int waypointIndex = 0;


    void OnCollisionEnter2D(Collision2D col)
    {
        player.Hp = 0;
        player.CheckDeath();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(monster);
    }




    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
