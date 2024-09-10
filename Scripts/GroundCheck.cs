using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    GameObject dustCloud;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
    }
}
