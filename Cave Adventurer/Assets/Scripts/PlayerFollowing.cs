using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour {

    // skrypt odpowiadający za podążanie kamery za graczem

    [SerializeField] private GameObject player;       // gracz
    private Vector3 offset;                           // offset

    void Start()
    {
        offset = transform.position - player.transform.position;        // ustawiamy offset na różnicę pozycji kamery i gracza
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;        // ustawiamy ruch kamery na pozycję gracza + offset
    }
}
