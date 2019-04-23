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
    public Enemy pU;
    float ingameTime;
    float powerUpTime;
    bool powerUpActive;
    

    public GameObject gameOverText, gameOverButton, Timer, player, EnemyObj, powerUp;

    // Start is called before the first frame update
    void Start()
    {

        gameOverText.SetActive(false);
        gameOverButton.SetActive(false);

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

        //      powerUpTime += Time.time;
        //
        //
        //     if (powerUpActive)
        //    {
        //       puat = 0;
        //        Debug.Log(puat);
        //       float seconds = (int)(powerUpTime % 60f);
        //        Debug.Log(seconds);
        //
        //    }
        //    if(powerUpActive && puat == 0)
        //   {
        //        if (puat >= 10)
        //        {
        //            Debug.Log("TIMES UP!");
        //            pU.powerUp = false;
        //
        //        }
        //     }

    }



    private void OnCollisionEnter(Collision collision)
    {
 
        if (collision.gameObject.tag.Equals("PowerUp"))
        {

            StartCoroutine("PowerUpActive");

        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            gameOverButton.SetActive(true);
            //gameObject.SetActive(false);
            Timer.SetActive(false);
            Debug.Log("DEAD");
            player.SetActive(false);
        }
    }
    IEnumerator PowerUpActive()
    {
        Debug.Log("COLLIDED");
        pU = EnemyObj.GetComponent<Enemy>();
        pU.powerUp = true;
        powerUp.SetActive(false);
        yield return new WaitForSeconds(10f);
        pU.powerUp = false;
    }


    private void FixedUpdate()
    {
        jump = false;
    }
}
