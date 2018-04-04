using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    public float speed;
    float cameraHeight;
    float cameraWidth;

    public GameObject effectEmeny;
    // Use this for initialization
    void Start()
    {
        speed = 5f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update () {
        shootBullet();
        destroyBullet();
    }

    public void shootBullet()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        start = StartCoroutine(Bullet());
    }


    Coroutine start;
    IEnumerator Bullet()
    {
        
        yield return new WaitForSeconds(5f);


    }

    public void destroyBullet()
    {
        if(transform.position.y > cameraHeight)
        {
            Destroy(this.gameObject);
        }
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "emeny")
		{
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
            Destroy(Instantiate(effectEmeny, this.transform.position, this.transform.rotation) as GameObject, 2);
            
		}
	}
}
