using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float sensitivity;
    public float jumpForce = 5;
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
            transform.position += transform.forward * speed * Time.deltaTime;
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
    }

    private void FixedUpdate()
    {
        jump = false;
    }
}
