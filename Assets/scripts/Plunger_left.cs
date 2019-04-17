using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger_left : MonoBehaviour
{
    // Start is called before the first frame update
    public float downTime, pressTime = 0;
    public float countdown = 2.0f;
    public bool release = false;
    public GameObject AttackWin;
    public GameObject DefendWin;
    public GameObject WarningLight;

    Animator AnimDuck;
    public GameObject plunger_left;
    
    public Color color = Color.yellow;
    public Renderer rend;
    float height = 2.0f;
    FMOD.Studio.EventInstance BGM;
    void colorChange()
    {
        color.r = 1f;
        color.g = 0.9f;
        color.b = 0.016f;
        color.a = 1f;
    }

    private void Awake()
    {
        BGM = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
    }

    void Start()
    {
        
        colorChange();
        AnimDuck = GetComponent<Animator>();
        //gameObject.GetComponent<Renderer>().material.color = new Color(243, color.g, 24, 255);
        rend = GetComponent<Renderer>();
        rend.material.color = color;
        //rend.material.shader = Shader.Find("_Color");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(BGM, this.transform, this.GetComponent<Rigidbody>());
        BGM.start();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DDR1Left") && release == false)
        {
            AnimDuck.SetBool("IsDuck", true);
            downTime = Time.time;
            pressTime = downTime + countdown;
           // plunger_left.transform.localScale = new Vector3(0f, 0f, 0f);
            release = true;
            StartCoroutine(ActiveWarning());
        }

        IEnumerator ActiveWarning()
        {
            yield return new WaitForSeconds(1);
            WarningLight.SetActive(true);

        }



        if (release = true && Time.time >= pressTime)
        {
            //transform.localScale = new Vector3(0.9f, 0.3f, height);
            AnimDuck.SetBool("IsDuck", false);
            release = false;
            WarningLight.SetActive(false);
        }

        if (Input.GetButtonUp("DDR1Left"))
        {
            AnimDuck.SetBool("IsDuck", false);
            //transform.localScale = new Vector3(0.9f, 0.3f, height);
            release = false;
        }

        if (height >= 22)
        {
            Debug.Log(height);
            AttackWin.SetActive(true);
            GameObject.Find("Timer").SendMessage("endTimer");
            FindObjectOfType<GameManager>().EndGame();
        }

        BGM.setParameterByName("Length", height * 0.05f);

    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Duck")
        {
            transform.localScale = new Vector3(0.7f, 1.2f, height + 2.0f);
            
            height = height + 2.0f;
            color.g = color.g - height *0.01f;
            rend.material.color = color;
            
          
        }
    }

    public void countDownEnd()
    {
       
        if (height >= 22)
        {
            Debug.Log("countdownend,gameover");
            AttackWin.SetActive(true);
            FindObjectOfType<GameManager>().EndGame();

        } else
        {
            DefendWin.SetActive(true);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}

