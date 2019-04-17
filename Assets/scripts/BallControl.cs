using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody rb;
    public int speed;
    public Transform sparkle;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector3(speed, 0, -speed));
        }
        else
        {
            rb.AddForce(new Vector3(-speed, 0, speed));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("GoBall", 0);

        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    //void oncollisionenter(collision coll)
    //{
    //    if (coll.collider.comparetag("player"))
    //    {
    //        vector2 vel;
    //        vel.x = rb.velocity.x;
    //        vel.y = (rb.velocity.y / 2) + (coll.collider.attachedrigidbody.velocity.y / 3);
    //        rb.velocity = vel;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Block")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Warning", GetComponent<Transform>().position);
            sparkle.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopSparkles());
        }


        //if (Input.GetButtonDown("DDR2Left"))
        //{
        //    if (collisionInfo.collider.tag == "SpringLeft")
        //    {
        //         Debug.Log("DuckHit");
        //        rb.velocity = new Vector3(-15, 0, 60);
        //    }


        //}



        if (collisionInfo.collider.tag == "SpringLeft")
        {
            rb.velocity = new Vector3(Random.Range(11.0f,18.0f), 0, 60);

  



            FMODUnity.RuntimeManager.PlayOneShot("event:/Bounce", GetComponent<Transform>().position);
            
        }


        if (collisionInfo.collider.tag == "SpringRight")
        {
            //rb.AddForce(new Vector3(speed*0.3f, 0, speed*0.6f));
            rb.velocity = new Vector3(Random.Range(-11.0f, -18.0f), 0, 60);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Bounce", GetComponent<Transform>().position);


        }


    }

    IEnumerator stopSparkles()
    {
        yield return new WaitForSeconds(.4f);
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }

  




}
