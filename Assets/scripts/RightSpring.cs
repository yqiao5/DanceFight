using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSpring : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animBounce.SetBool("IsBounce", true);



        }


        //if (Input.GetButtonUp("DDR2Right"))
        //{
        //    animBounce.SetBool("IsBounce", false);

        //}

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animBounce.SetBool("IsBounce", false);



        }


    }
}
