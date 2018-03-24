using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        shootBullet();
        destroyBullet();
    }

    public void shootBullet()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void destroyBullet()
    {
        if(transform.position.y > 5.55f)
        {
            Destroy(this.gameObject);
        }
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "emeny")
		{
			Destroy (this.gameObject);
			Destroy (collision.gameObject);
		}
	}
}
