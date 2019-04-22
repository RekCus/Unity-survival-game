using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    Text counterText;

    public float seconds, minutes;


    // Start is called before the first frame update
    void Start()
    {

        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");


       // if(minutes >= 1)
      //  {
      //      counterText.text = "YOU WIN!!!!" + "\n"+ "Press 'space' to restart" ;

       //     if (Input.GetKey(KeyCode.Space))
      //      {

      //          Application.LoadLevel(Application.loadedLevel);


       //     }
      //  }



    }
}
