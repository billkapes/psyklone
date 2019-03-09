using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject orbPrefab;
    float timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(orbPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Instantiate(orbPrefab);
            timer = 5f;
        }
        
    }
}
