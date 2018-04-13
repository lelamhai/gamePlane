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
        ShootBullet();
        DestroyBullet();
    }

    public void ShootBullet()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void DestroyBullet()
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
            Singleton.Instance.Point += 1;
        }
	}
}
