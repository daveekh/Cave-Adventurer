using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGhost : MonoBehaviour {

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject ghost;
    [SerializeField] private Player player;
    [SerializeField] private SpriteRenderer ghostRend;
    public float moveSpeed;
    public float rotationSpeed;

    void OnTriggerEnter2D(Collider2D col)
    {
        player.Hp = 0;
        player.CheckDeath();
        if (ghost != null)
        {
            Destroy(ghost);
        }
    }


    void Update()
    {
        if (player.Hp > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);

            if ( (angle > (-180) && angle < (-90)) || (angle < 180 && angle > 90) ) { ghostRend.flipX = true; }
            if ( (angle < 0 && angle > (-90)) || (angle > 0 && angle < 90) ) { ghostRend.flipX = false; }
        }
    }
}
