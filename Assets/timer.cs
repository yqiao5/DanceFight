using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float mainTimer;

    public Text timerText;
    private float startTime;
    private bool isEnd = false;

    private bool canCount = true;
    private bool doOnce = false;
   

    // Start is called before the first frame update
    void Start()
    {
        startTime = mainTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
            return;

        if (startTime >= 0.0f && canCount)
        {
            startTime -= Time.deltaTime;
            float t = startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
        else if (startTime <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            timerText.text = "0.00";
            startTime = 0.0f;
            GameOver();
        }

    }

    public void endTimer()
    {
        isEnd = true;
    }

    public void ResetBtn()
    {
        startTime = mainTimer;
        canCount = true;
        doOnce = false;

    }

    void GameOver()
    {
        GameObject.Find("Plunger_Right").SendMessage("countDownEnd");
        GameObject.Find("Plunger_Left").SendMessage("countDownEnd");
    }

}
