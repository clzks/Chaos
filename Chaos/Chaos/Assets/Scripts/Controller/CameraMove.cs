using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 PlayerPos;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            this.transform.position = PlayerPos;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(0, 0, -1);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(0, 0, 1);
        }
    }
}
