using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 8;
    int MaxDist = 10;
    int MinDist = 1;
    public bool powerUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);


        if (powerUp && Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position -= transform.forward * MoveSpeed * Time.deltaTime;
        }

        else if (!powerUp && Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }

       
    }
}
