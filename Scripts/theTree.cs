using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theTree : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public GameObject bloodEffect;

    public bool drops;
    public GameObject theDrops;
    public Transform dropPoint;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //player hurt animation
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        if (currentHealth <= 0)
        {
            Die();
            if (drops) Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
        }

    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("enemy died");
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
}
