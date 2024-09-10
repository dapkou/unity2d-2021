using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEAT : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        GameContrilScript.health -= 1;
    }
    
}
