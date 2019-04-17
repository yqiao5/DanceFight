using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger_rightNew : MonoBehaviour
{
    // Start is called before the first frame update
    public float downTime, pressTime, warningTime = 0;
    public float countdown = 2.0f;
    public bool release = false;

    public GameObject plunger_right;
    Animator AnimDuck;
    float height = 2.0f;
    public GameObject AttackWin;
    public GameObject DefendWin;
    public GameObject WarningLight;

    public Color color = Color.yellow;
    public Renderer rend;

    void colorChange()
    {
        color.r = 1f;
        color.g = 0.9f;
        color.b = 0.016f;
        color.a = 1f;
    }

    void Start()
    {
        colorChange();
        AnimDuck = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
        rend.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //   // Debug.Log("s");
        //    plunger_right.transform.localScale = new Vector3(0f, 0f, 0f);
        //    //plunger_left.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);

        //}

        //if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    transform.localScale = new Vector3(0.9f, 0.3f, height);
        //}

        if (Input.GetButtonDown("DDR1Right") && release == false)
        {
            AnimDuck.SetBool("IsDuck", true);
            downTime = Time.time;
            pressTime = downTime + countdown;
            //warningTime = downTime + countdown-1.0f;
            //plunger_right.transform.localScale = new Vector3(0f, 0f, 0f);
            release = true;
            StartCoroutine(ActiveWarning());
        }


        IEnumerator ActiveWarning()
        {
           yield return new WaitForSeconds(1);
           WarningLight.SetActive(true);
            

        }

        //if(Time.time>= warningTime && release == true)
        //{
        //    WarningLight.SetActive(true);

        //}

        if (release = true && Time.time >= pressTime)
        {
            AnimDuck.SetBool("IsDuck", false);
            WarningLight.SetActive(false);
            transform.localScale = new Vector3(0.9f, 0.3f, height);
            
            release = false;
        }

        if (Input.GetButtonUp("DDR1Right"))
        {
            AnimDuck.SetBool("IsDuck", false);
            //transform.localScale = new Vector3(0.9f, 0.3f, height);
            release = false;
        }


        if (height >= 22)
        {
            // Debug.Log(height);
            AttackWin.SetActive(true);
            GameObject.Find("Timer").SendMessage("endTimer");
        }

        //if (Input.GetButton("DDRRight"))
        //{ 
        //    Debug.Log("DDRRight");
        //}
    }


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Duck")
        {
            transform.localScale = new Vector3(0.7f, 1.2f, height + 2.0f);

            height = height + 2.0f;
            color.g = color.g - height * 0.01f;
            rend.material.color = color;
        }


    }

    public void countDownEnd()
    {
        //Debug.Log("countdownend");
        
        if (height >= 22)
        {
            Debug.Log("countdownend,gameover");
            AttackWin.SetActive(true);

        }
        else
        {
            DefendWin.SetActive(true);
        }
    }
}




