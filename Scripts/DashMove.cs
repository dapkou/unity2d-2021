using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float starDahTime;
    private int direction;
    public GameObject dashEffect;
    public Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = starDahTime;
    }

    // Update is called once per frame
    void Update()
    {
    if(direction == 0)
        {
            //if (Input.GetKeyDown(KeyCode.LeftArrow))
            //{
            //    Instantiate(dashEffect, transform.position, Quaternion.identity);
            //    direction = 1;
            //}
            //else if (Input.GetKeyDown(KeyCode.RightArrow))
            //{
            //    Instantiate(dashEffect, transform.position, Quaternion.identity);
            //    direction = 2;
            //}
            //else 
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 4;
            }
        }   
    else {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = starDahTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                camAnim.SetTrigger("shake");
            }
            //if (direction == 1)
            //{
            //    rb.velocity = Vector2.left * dashSpeed;
            //}
            //else if (direction == 2)
            //{
            //    rb.velocity = Vector2.right * dashSpeed;
            //}
            //else 
            if (direction == 3)
            {
                rb.velocity = Vector2.up * dashSpeed;
            }
            else if (direction == 4)
            {
                rb.velocity = Vector2.down * dashSpeed;
            }
        }
    }
}
