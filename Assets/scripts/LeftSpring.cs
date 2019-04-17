using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSpring : MonoBehaviour
{
    public GameObject duck;
    Animator animBounce;
    // Start is called before the first frame update
    void Start()
    {

       animBounce = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("DDR2Left"))
        //{
        //    //Debug.Log("DDR2Left");
        //    animBounce.SetBool("IsBounce", true);


        //}

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("DDR2Left");
            animBounce.SetBool("IsBounce", true);


        }

        //if (Input.GetButtonUp("DDR2Left"))
        //{
        //    animBounce.SetBool("IsBounce", false);

        //}
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //Debug.Log("DDR2Left");
            animBounce.SetBool("IsBounce", false);


        }

    }


}
