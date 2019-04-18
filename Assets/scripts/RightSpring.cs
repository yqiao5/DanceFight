using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSpring : MonoBehaviour
{

    public float downTime, pressTime = 0;
    public float countdown = 2.0f;
    public bool release = false;
    Animator animBounce;
    // Start is called before the first frame update
    void Start()
    {
        animBounce = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("DDR2Right"))
        //{
        //    animBounce.SetBool("IsBounce", true);



        //}

        if (Input.GetButtonDown("DDR2Right") && release ==false)
        {
            animBounce.SetBool("IsBounce", true);
            downTime = Time.time;
            pressTime = downTime + countdown;
            release = true;

        }

        if (release = true && Time.time >= pressTime)
        {
            animBounce.SetBool("IsBounce", false);
            release = false;
        }


        //if (Input.GetButtonUp("DDR2Right"))
        //{
        //    animBounce.SetBool("IsBounce", false);

        //}

        if (Input.GetButtonUp("DDR2Right"))
        {
            animBounce.SetBool("IsBounce", false);



        }


    }
}
