using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyControl : MonoBehaviour {
    private float speed;
	// Use this for initialization
	void Start () {
        speed = 3f;
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
		if(transform.position.y < -5.55f)
		{
			Destroy (this.gameObject);
		}
	}
}
