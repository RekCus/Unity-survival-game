using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float sensitivity;
    public float jumpForce = 5;
    float sprintspeed;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * (speed+sprintspeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * sensitivity * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprintspeed = speed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintspeed = 0;
        }
    }

    private void FixedUpdate()
    {
        jump = false;
    }
}
