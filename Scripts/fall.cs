using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player")){
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 1f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
