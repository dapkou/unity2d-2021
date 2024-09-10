using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
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

        // hurt animation
        animator.SetTrigger("Hurt");
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
        animator.SetBool("isDead", true);
       
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
