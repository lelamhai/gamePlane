﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public GameObject listBG;
    public GameObject bullet;
    private float speed;
    float cameraHeight;
    float cameraWidth;

	public Joytick moveJoytick;
<<<<<<< HEAD
	public Vector3 direction;
=======
    private Vector3 direction;
    private float xMin, xMax, yMin, yMax;
>>>>>>> 8a6a354fb94d05d089f96b76106fc510ed0806e5
    // Use this for initialization
    void Start () {


        speed = 0.1f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
<<<<<<< HEAD


=======
        xMax = cameraWidth; // I used 50 because the size of player is 100*100
        xMin = -cameraWidth;
        yMax = cameraHeight;
        yMin = -cameraHeight;
>>>>>>> 8a6a354fb94d05d089f96b76106fc510ed0806e5
    }
	
	// Update is called once per frame
	void Update () {
        direction = moveJoytick.InputDirection;
        if (direction.magnitude != 0)
        {
            transform.position += direction * speed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), 0f);//to restric movement of player
        }
        inputControl();
<<<<<<< HEAD
=======

>>>>>>> 8a6a354fb94d05d089f96b76106fc510ed0806e5
    }

    public void inputControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x > -cameraWidth)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x < cameraWidth)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if(transform.position.y < cameraHeight)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > -cameraHeight)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

	public void clickBullet()
	{
		Instantiate(bullet, transform.position, Quaternion.identity);
	}
}
