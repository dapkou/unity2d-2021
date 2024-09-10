using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private Transform mainCameraTran;
    private Transform cameraDir;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;


        mainCameraTran = Camera.main.gameObject.transform;
        GameObject cameraDir_obj = new GameObject();
        cameraDir_obj.transform.parent = transform;
        cameraDir_obj.transform.localPosition = Vector3.zero;
        cameraDir_obj.name = "CameraDir";
        cameraDir = cameraDir_obj.transform;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        if (mainCameraTran)
        {
            cameraDir.eulerAngles = new Vector3(0, mainCameraTran.eulerAngles.y, 0);
        }
    }
}
