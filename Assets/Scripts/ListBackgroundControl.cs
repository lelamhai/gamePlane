using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBackgroundControl : MonoBehaviour {
    public SpriteRenderer[] listBG;
    public float speed;
    private float distance;
    float cameraHeight;
    float cameraWidth;

    float positionStart;


    // Use this for initialization
    void Start () {
        speed = 3f;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

       
    }
	
	// Update is called once per frame
	void Update () {
        ListBGRun();
        if (Input.touchCount > 0)
            print(Input.touchCount);
    }

    public void ListBGRun()
    {
        for (int i = 0; i < listBG.Length; i++)
        {
            listBG[i].transform.position = new Vector3(listBG[i].transform.position.x, listBG[i].transform.position.y - speed * Time.deltaTime, listBG[i].transform.position.z);
            if(listBG[i].transform.position.y < -cameraHeight)
            {
                listBG[i].transform.position = new Vector3(listBG[i].transform.position.x, cameraHeight, listBG[i].transform.position.z);
            }
        }
    }

    public void getHeightBG()
    {

    }
}
