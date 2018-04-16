using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmenyControl : MonoBehaviour {
    public float speed;
    float cameraHeight;
    float cameraWidth;

    // Use this for initialization
    void Start () {
        speed = 5f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void Update () {
        ShootBulletEmeny();
        DestroyBulletEmeny();
    }

    private void ShootBulletEmeny()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void DestroyBulletEmeny()
    {
        if (transform.position.y < -cameraHeight)
        {
            Destroy(this.gameObject);
        }
    }
}
