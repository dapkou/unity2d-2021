using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEAL : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameContrilScript.health += 1;
        if (col.gameObject.name.Equals("Player"))
            Destroy(gameObject);
    }
  
}
