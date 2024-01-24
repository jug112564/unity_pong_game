using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float time;
    private int min;
    private int sec;
    private bool isTimeOver;
    void Start()
    {
        timerText.text = "03 : 00";
        time = 180;
        isTimeOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        min = (int)time / 60;
        sec = ((int)time - min * 60) % 60;

        if (min <= 0 && sec <= 0)
        {
            if (isTimeOver==false)
            {
                isTimeOver = true;
                timerText.text = 0.ToString() + " : " + 0.ToString();
                GameManager.instance.EndGame();
            }

        }
        else
        {
            if (sec >= 60)
            {
                min += 1;
                sec -= 60;
            }
            else
            {
                timerText.text = min.ToString() + " : " + sec.ToString();

            }
        }
    }
}
