using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    Text counterText;

    public float seconds, minutes;
    float startTime;
    float elapsedTime;
    public GameObject winText, gameOverButton, timer, player;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        counterText = GetComponent<Text>() as Text;
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        elapsedTime = Time.time - startTime;
        minutes = (int)(elapsedTime / 60f);
        seconds = (int)(elapsedTime % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        
        if(minutes == 1)
        {
            Debug.Log("YOU WIN!!!");

            winText.SetActive(true);
            gameOverButton.SetActive(true);
            timer.SetActive(false);
            player.SetActive(false);


        }


    }
}
