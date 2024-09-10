using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneMany : MonoBehaviour
{
    public int health;
    public float speed = 0.5f;
    private float dazedTime;
    public float startDazedTime;



    private Animator anim;
    public GameObject bloodEffect;

    public bool drops;
    public GameObject theDrops;
    public Transform dropPoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {

            Destroy(gameObject);

        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        //+音樂
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damege TAKEN !");

    }
    void FixedUpdate()
    {
        if (drops) Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
    }
}
