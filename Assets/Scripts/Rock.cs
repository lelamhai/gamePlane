using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    private float speed;
    float cameraHeight;
    float cameraWidth;

    Vector3 positionInit;

    public bool flagRun;
    public bool flagDestroy;
    // Use this for initialization
    void Start () {
        speed = 2f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
        positionInit = transform.position;
        flagRun = false;
        flagDestroy = false;
    }
	
	// Update is called once per frame
	void Update () {
        RunRock();
        DestroyRock();
    }

    public void RunRock()
    {
        if(flagRun)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -speed*Time.deltaTime, transform.position.z);
        }
    }

    public void DestroyRock()
    {
        if(transform.position.y <= -cameraHeight)
        {
            transform.position = positionInit;
            flagDestroy = true;
        }
    }
}
