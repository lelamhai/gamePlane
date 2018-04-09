using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmeny : MonoBehaviour {
	public float repeatEmeny;
	public float deplayEmeny;
	public float positionAtEmeny;
	public GameObject emeny;

    float cameraHeight;
    float cameraWidth;
    // Use this for initialization
    void Start () {
		repeatEmeny = Random.Range (3f, 5f);
		deplayEmeny = Random.Range (3f,5f);
		InvokeRepeating ("SpawnEmenys", deplayEmeny, repeatEmeny);
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
       
    }
	
	// Update is called once per frame
	void Update () {
		positionAtEmeny = Random.Range (-cameraWidth, cameraWidth);
	}

	private void SpawnEmenys()
	{
		Instantiate(emeny, new Vector3(positionAtEmeny, transform.position.y, 0), transform.rotation);
	}
}
