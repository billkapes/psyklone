using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{

    float timer, shrinkScale = 0f, speedScale = 1f, growScale = 0.1f;
    bool shrink;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
        int[] randomXs = new int[] { -4, 4 };
        int[] randomYs = new int[] { -4, 4 };

        transform.SetPositionAndRotation(
            new Vector3(
                randomXs[Random.Range(0, randomXs.Length)],
                randomXs[Random.Range(0, randomYs.Length)],
                0f
            ),
            Quaternion.identity
        );

        GetComponent<Rigidbody>().velocity = (Vector3.zero - transform.position).normalized * speedScale++;
        

        Destroy(gameObject, 8f);
        Invoke("SetShrinkFlag", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        growScale += Time.deltaTime;
        transform.localScale = Vector3.one * growScale / 8f;

        //targeting player cycle
        timer -= Time.deltaTime;
        if (timer < 0f)
        {

            Invoke("SetVel", 0.4f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            timer = 2f;
        }


        if (shrink)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, shrinkScale);
            transform.Rotate(transform.forward, 2f);
            shrinkScale += Time.deltaTime;
        }
    }

   

    void SetShrinkFlag() {
        shrink = true;
    }


    void SetVel() {
        GetComponent<Rigidbody>().velocity = 
            (GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Random.Range(-1,1), Random.Range(-1f, 1f))
                - transform.position).normalized * speedScale++;
    }
}
