using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerMovement : MonoBehaviour
{
    public float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //move up in z
            transform.Translate(new Vector3(0, 0, .01f * speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            //move down in z
            transform.Translate(new Vector3(0, 0, -.01f * speed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //down x
            transform.Translate(new Vector3(-0.01f* speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //up in x
            transform.Translate(new Vector3(.01f * speed, 0, 0));
        }
    }
}
