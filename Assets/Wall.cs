using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, -2f, 0f);
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
