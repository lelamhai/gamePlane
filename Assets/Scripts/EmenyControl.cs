using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyControl : MonoBehaviour
{
    private float speed;
    float cameraHeight;
    float cameraWidth;

    private float widthEmeny;

    public GameObject BulletEmeny;
    // Use this for initialization
    void Start()
    {
        speed = 3f;
        widthEmeny = (GetComponent<SpriteRenderer>().bounds.size.x) / 2;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
        if(Singleton.Instance.Point >= 10)
        {
            StartCoroutine(ShootEmenyBullet());
        }

    }

    // Update is called once per frame
    void Update()
    {
        flyEmeny();
        destroyEmeny();
    }

    public void flyEmeny()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void destroyEmeny()
    {
        if (transform.position.y < -cameraHeight)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShootEmenyBullet()
    {
        yield return new WaitForSeconds(Random.Range(1,3f));
        Vector3 current = transform.position;
        current.y -= 0.5f;
        Instantiate(BulletEmeny, current, Quaternion.identity);
        StartCoroutine(ShootEmenyBullet());
    }
}
