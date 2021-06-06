using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCrtl : MonoBehaviour
{

    private float camSpeed = 20f;
    
    void Update()
    {
        CamCtrlInput();
    }

    private void CamCtrlInput()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.z += camSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= camSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += camSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= camSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
