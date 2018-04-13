using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour {
    public GameObject rock;
    private List<GameObject> listRock = new List<GameObject>();

    float cameraHeight;
    float cameraWidth;

    float rockWidth;
    float rockHeight;

    // Use this for initialization
    void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        rockWidth = rock.GetComponent<SpriteRenderer>().bounds.size.x;
        rockHeight = rock.GetComponent<SpriteRenderer>().bounds.size.y;

        CopyRock();
    }
	
	// Update is called once per frame
	void Update () {
        SetPositionRock(rockWidth, rockHeight);
        StartCoroutine("RunRock");
    }

    public void SetPositionRock(float rockWidth, float rockHeight)
    {
        float widthRandom;
        if (true)
        {
            widthRandom = Random.Range(-cameraWidth + rockWidth, cameraWidth - rockWidth);
        }
        transform.position = new Vector3(widthRandom, cameraHeight+rockHeight, 0);
    }



    public void CopyRock()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject rocks = Instantiate(rock, new Vector3(0, transform.position.y, 0), transform.rotation);
            rocks.transform.parent = transform;
            listRock.Add(rocks);
        }
    }

    IEnumerator RunRock()
    {
        for (int i = 0; i < listRock.Count; i++)
        {
            yield return new WaitForSeconds(Random.Range(1,8));
            if (!listRock[i].GetComponent<Rock>().flagRun)
            {
                listRock[i].GetComponent<Rock>().flagRun = true;
                listRock[i].GetComponent<Rock>().RunRock();
            }
        }
    }
}
