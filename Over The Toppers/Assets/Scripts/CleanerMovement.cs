using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerMovement : MonoBehaviour
{
    public float hAxis;
    public float vAxis;

    public float speed = 20f;
    private Rigidbody rb;

    public GameObject model;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            GameManager.totalMessCleaned++;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //move up in z
            hAxis = 0;
            vAxis = 1;
            model.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //move down in x
            hAxis = -1;
            vAxis = 0;
            model.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //down z
            hAxis = 0;
            vAxis = -1;
            model.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //up in x
            hAxis = 1;
            vAxis = 0;
            model.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            hAxis = 0;
            vAxis = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hAxis * speed, 0f, vAxis * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rat")
        {
            Destroy(other.gameObject);
        }
    }
}
