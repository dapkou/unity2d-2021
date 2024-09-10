using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPrev : MonoBehaviour
{
  
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            SceneManager.LoadScene("S1");
        
    }
}
