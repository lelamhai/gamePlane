using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyControl : MonoBehaviour {
    private float speed;
	// Use this for initialization
	void Start () {
        speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        flyEmeny();
    }

    public void flyEmeny()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
