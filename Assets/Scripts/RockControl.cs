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

    // Use this for initializationh
    void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        rockWidth = rock.GetComponent<SpriteRenderer>().bounds.size.x;
        rockHeight = rock.GetComponent<SpriteRenderer>().bounds.size.y;
        CopyRock();
        StartRandomRock();
    }

    IEnumerator StartRun;
    public void StartRandomRock()
    {
        StartRun = RunRock();
        StartCoroutine(StartRun);
    }

    public void StopRunRock()
    {
        if (StartRun!=null)
        {
            StopCoroutine(StartRun);
            StartRun = null;
        }
    }

    public void CopyRock()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject rocks = Instantiate(rock, new Vector3(0, transform.position.y, 0), transform.rotation);
            //Rigidbody2D rigidbodyRocks = rocks.AddComponent<Rigidbody2D>();
            //rigidbodyRocks.gravityScale = 0;
            rocks.AddComponent<BoxCollider2D>();
            BoxCollider2D col = rocks.GetComponent<BoxCollider2D>();
            col.isTrigger = true;
            rocks.transform.parent = transform;
            listRock.Add(rocks);
        }
    }

    IEnumerator RunRock() 
    {
        for (int i = 0; i < listRock.Count; i++)
        {
            yield return new WaitForSeconds(3f); 

            if (!listRock[i].GetComponent<Rock>().flagRun)
            {
                listRock[i].GetComponent<Rock>().flagRun = true;
                listRock[i].GetComponent<Rock>().RandomPosition();
                if (i == listRock.Count-1)
                {
                    StartRandomRock();
                }
            }
        }
    }
}
