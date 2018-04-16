using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    private float speed;
    float cameraHeight;
    float cameraWidth;

    float rockWidth;
    float rockHeight;
    float widthRandom;
    Vector3 positionInit;

    public bool flagRun;
    public bool flagDestroy;
    
    // Use this for initialization
    void Start () {
        speed = 2f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        rockWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        rockHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        positionInit = transform.position;
        flagRun = false;
    }
   
	void Update () {
        RunRock();
    }

    public void RandomPosition()
    {
        widthRandom = Random.Range(-cameraWidth + rockWidth, cameraWidth - rockWidth);
        transform.position = new Vector3(widthRandom, positionInit.y, transform.position.z);
    }

    public void RunRock()
    {
        // flagRun true/false rock 
        if (flagRun)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }

        if (transform.position.y <= (-cameraHeight- rockHeight) && flagRun)
        {
            flagRun = false;
        }
    }

    public void DestroyRock()
    {
        if(transform.position.y <= -cameraHeight)
        {
            transform.position = positionInit;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Bullet(Clone)")
        {
            this.transform.position = new Vector3(0, -cameraHeight, 0);
            Destroy(collision.gameObject);
        }
    }
}
