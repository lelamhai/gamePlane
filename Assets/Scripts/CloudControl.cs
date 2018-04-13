using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour {
    public List<SpriteRenderer> listCloud = new List<SpriteRenderer>();
    float cameraHeight;
    float cameraWidth;
    int indexCloud;
    float speed;

    bool flagCloud;
    bool flagPositionCloud;

    float widthCloud;
    float heightCloud;

    public GameObject MainGame;
	// Use this for initialization
	void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
        indexCloud = 0;
        speed = 1f;
        flagCloud = true;
        widthCloud = (listCloud[3].GetComponent<SpriteRenderer>().bounds.size.x)/ 2;
        heightCloud = (listCloud[3].GetComponent<SpriteRenderer>().bounds.size.y) / 2;
    }
	
	// Update is called once per frame
	void Update () {
        if(MainGame.GetComponent<MainGame>().DisplayCloud())
        {
            SetPositionCloud();
        }
        DestroyCloud();
    }

    void SetPositionCloud()
    {
        if (flagCloud)
        {
            indexCloud = Random.Range(0, listCloud.Count);
            float widthRandom = Random.Range(-cameraWidth + widthCloud, cameraWidth - widthCloud);
            transform.position = new Vector3(widthRandom, cameraHeight + heightCloud, transform.position.z);
            flagCloud = false;
        }
        listCloud[indexCloud].transform.position = new Vector3(listCloud[indexCloud].transform.position.x, listCloud[indexCloud].transform.position.y - speed * Time.deltaTime, listCloud[indexCloud].transform.position.z);
    }

    public void DestroyCloud()
    {
        if(listCloud[indexCloud].transform.position.y < -cameraHeight)
        {
            flagCloud = true;
            listCloud[indexCloud].transform.position = new Vector3(listCloud[indexCloud].transform.position.x, cameraHeight + heightCloud, listCloud[indexCloud].transform.position.z);
        }
    }
}
