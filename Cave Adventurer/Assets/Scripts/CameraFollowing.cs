using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowing : MonoBehaviour {

    // skrypt odpowiadający za podążaniem jakiegoś obiektu za graczem

    [SerializeField] private GameObject player;       // gracz
    private Vector3 offset;                           // offset

    void Start()
    {
        offset = transform.position - player.transform.position;        // ustawiamy offset na różnicę pozycji obiektu i gracza
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;        // ustawiamy ruch obiektu na pozycję gracza + offset
    }
}
