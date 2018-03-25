using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyControl : MonoBehaviour {
    private float speed;
	float cameraHeight;
    float cameraWidth;
    // Use this for initialization
    void Start()
    {
        speed = 3f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void Update () {
        flyEmeny();
		destroyEmeny ();
    }

    public void flyEmeny()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

	public void destroyEmeny()
	{
		if(transform.position.y < -cameraHeight)
		{
			Destroy (this.gameObject);
		}
	}
}
