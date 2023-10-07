using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerMovement : MonoBehaviour
{
    public float speed = 6f;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //move up in z
            transform.position = transform.position + new Vector3(0, 0, .01f * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //move down in z
            transform.position = transform.position + new Vector3(0, 0, -.01f * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //down x
            transform.position = transform.position + new Vector3(-.01f * speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //up in x
            transform.position = transform.position + new Vector3(.01f * speed, 0, 0);
        }
    }
}
