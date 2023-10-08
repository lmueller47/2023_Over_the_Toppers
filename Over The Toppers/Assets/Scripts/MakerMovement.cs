using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakerMovement : MonoBehaviour
{
    public float hAxis;
    public float vAxis;

    public float speed = 20f;
    private Rigidbody rb;
    public static List<GameObject> toppings = new List<GameObject>();

    public string collision = "";

    public bool destroying = false;

    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //move up in z
            hAxis = 0;
            vAxis = 1;
            model.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //move down in z
            hAxis = -1;
            vAxis = 0;
            model.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //down x
            hAxis = 0;
            vAxis = -1;
            model.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.D))
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

        if(Input.GetKeyDown(KeyCode.Space) && collision == "Oven" && !destroying && GameManager.pizzaDone == true)
        {
            destroying = true;
            GameManager.pizzaMade++;
            GameManager.totalPizzaMade++;
            GameManager.stackCount = 0;
            GenerateOrders.Order();

            Debug.Log("pm = " + GameManager.pizzaMade);
            //destroy the topping

            for (int i = 0; i < toppings.Count; i++)
            {
                Destroy(toppings[i]);
            }
            toppings.Clear();
            destroying = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && collision == "Can" && !destroying)
        {
            destroying = true;
            //destroy the topping
            for (int i = 0; i < toppings.Count; i++)
            {
                Destroy(toppings[i]);
            }
            toppings.Clear();

            GameManager.stackCount = 0;
            destroying = false;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hAxis * speed, 0f, vAxis * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oven")
        {
            collision = "Oven";
        }
        if (other.gameObject.tag == "Can")
        {
            collision = "Can";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collision = "";
    }
}
