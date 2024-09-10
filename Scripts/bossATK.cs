using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossATK : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            GameContrilScript.health -= 1;
    }
}
