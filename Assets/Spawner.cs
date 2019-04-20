using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool canSpawn;

    
    public GameObject orbPrefab, wallPrefab, warningPrefab;
    float timer = 5f, wallMargin = 1.5f, redMargin = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(orbPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0f)
        {
            var temp = Random.Range(0, 2);
            var result = temp == 1 ? "RedSpawnCycle" : "WallSpawnCycle";


            StartCoroutine(result);
            timer = 10f;
        }

    }

    IEnumerator WallSpawnCycle()
    {
        var tempWarning = Instantiate(warningPrefab);
        tempWarning.GetComponent<MeshRenderer>().material.color = Color.yellow;
        


        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(wallPrefab, new Vector3(wallMargin, 6f, 0f), Quaternion.identity);
            wallMargin *= -1f;
            yield return new WaitForSeconds(2);

        }
    }

    IEnumerator RedSpawnCycle()
    {
        var tempWarning = Instantiate(warningPrefab);
        tempWarning.GetComponent<MeshRenderer>().material.color = Color.red;

        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(orbPrefab, new Vector3(redMargin, 6f, 0f), Quaternion.identity);
            redMargin *= -1f;
            yield return new WaitForSeconds(2);

        }
    }
}
