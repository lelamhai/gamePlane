using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public GameObject listBG;
    public GameObject bullet;
    private float speed;
    float cameraHeight;
    float cameraWidth;

	public Joytick moveJoytick;
	public Vector3 direction;
    // Use this for initialization
    void Start () {
        speed = 5f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;


    }
	
	// Update is called once per frame
	void Update () {
        inputControl();
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
