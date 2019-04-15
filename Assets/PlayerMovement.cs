using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    SPINING, SHOOTING, SHOOT
};

public class PlayerMovement : MonoBehaviour
{
    State myState;
    public float shootPower, torpuePower, timerValue;
    public float timer, aiTimer, horizLimit, vertLimit;
    public bool canMove;
    

    // Start is called before the first frame update
    void Start()
    {
        myState = State.SPINING;
        timer = timerValue;
        aiTimer = 1f;
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        //aiTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) || aiTimer < 0f)
        {
            aiTimer = Random.Range(0.1f, 2f);
      
            if (myState == State.SPINING)
            {
                myState = State.SHOOT;
                var main = GetComponentInChildren<ParticleSystem>().main;
                main.startSpeed = 9f;
                //GetComponentInChildren<ParticleSystem>().Play();


            }
        }    
    }

    private void LateUpdate()
    {
        
    }

    private void OnBecameInvisible()
    {
        if (Mathf.Abs(transform.position.x) > horizLimit)
        {
            transform.position = new Vector3(-transform.position.x - 0.2f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y - 0.2f, transform.position.z);

        }
    }


    void FixedUpdate()
    {
        

        switch (myState)
        {
            case State.SPINING:
                GetComponent<Rigidbody>().AddTorque(Vector3.back * torpuePower);
                break;
            case State.SHOOTING:
                timer -= Time.fixedDeltaTime;
                if (timer < 0f)
                {
                    myState = State.SPINING;
                    GetComponent<Animator>().SetTrigger("Spin");
                    var main = GetComponentInChildren<ParticleSystem>().main;
                    main.startSpeed = 2f;
                    //GetComponentInChildren<ParticleSystem>().Play();

                    timer = timerValue;
                }
                break;
            case State.SHOOT:
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                GetComponent<Rigidbody>().AddForce(transform.up * shootPower);
                GetComponent<Animator>().SetTrigger("Shoot");
                myState = State.SHOOTING;
                
                break;
            default:
                break;
        }

        //GetComponent<Rigidbody>().AddForce(transform.up * .2f);
    }
}
