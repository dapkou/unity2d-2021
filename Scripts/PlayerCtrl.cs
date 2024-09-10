using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D playerRigidbody2D;
    public float speedX;
    public float horzontalDirection;
    const string HORIZONTAL = "Horizontal"; //房打錯

    [Range(0,150)]
    public float xForce;
    float speedY;

   void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void MovementX()
    {
        horzontalDirection = Input.GetAxis(HORIZONTAL);
        playerRigidbody2D.AddForce(new Vector2(xForce*horzontalDirection,0));
    }
    void Update()
    {
        MovementX();
        speedX = playerRigidbody2D.velocity.x;
    }
}
