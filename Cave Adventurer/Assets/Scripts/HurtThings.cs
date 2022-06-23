using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HurtThings : MonoBehaviour
{
    // skrypt odpowiadający za przeszkody raniące gracza

    [SerializeField] Player player;
    [SerializeField] private bool death = false;
    [SerializeField] private bool _2Hp = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        player.Hp = 0;
        player.CheckDeath();
    }

}
