using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameController : MonoBehaviour
{
    Camera mainCam;
    PlayerMovement thePlayer;
    Spawner theSpawner;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        theSpawner = GameObject.FindObjectOfType<Spawner>();
        thePlayer = GameObject.FindObjectOfType<PlayerMovement>();
        mainCam = GameObject.FindObjectOfType<Camera>();
        mainCam.fieldOfView = 12f;
        //mainCam.transform.SetParent(thePlayer.transform);
        thePlayer.torpuePower = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            thePlayer.canMove = false;
            theSpawner.canSpawn = false;
            mainCam.DOFieldOfView(12, 1);

            thePlayer.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            thePlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
            startButton.transform.DOLocalMoveY(-727.4f, 1);

        }
    }

    public void StartButtonPress() {
        theSpawner.canSpawn = true;
        thePlayer.canMove = true;
        thePlayer.torpuePower = 10f;
        //mainCam.transform.SetParent(null);
        mainCam.DOFieldOfView(60, 1);
        //mainCam.fieldOfView = 60f;
        startButton.transform.DOLocalMoveY(-1100, 1);
    }
}
