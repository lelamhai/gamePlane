using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmeny : MonoBehaviour {
	public float repeatEmeny;
	public float deplayEmeny;
	public float positionAtEmeny;
	public GameObject emeny;
	// Use this for initialization
	void Start () {
		repeatEmeny = Random.Range (3f, 5f);
		deplayEmeny = Random.Range (3f,5f);
		InvokeRepeating ("SpawnEmenys", deplayEmeny, repeatEmeny);
	}
	
	// Update is called once per frame
	void Update () {
		positionAtEmeny = Random.Range (-6f,6f);
	}

	private void SpawnEmenys()
	{
		Instantiate(emeny, new Vector3(positionAtEmeny, transform.position.y, 0), transform.rotation);
	}
}
