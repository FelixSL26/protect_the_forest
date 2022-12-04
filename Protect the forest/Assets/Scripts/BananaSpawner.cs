using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public bool isBanana;

    public float minTime;
    public float maxTime;
    public float time;

    public GameObject Banana;
    public Vector2 minPos;
    public Vector2 maxPos;
    Vector3 pos;
    // Start is called before the first frame update
    private void Start()
    {
        time = Random.Range(minTime, maxTime);
        if (!isBanana)
        {
            pos.x = Random.Range(minPos.x, maxPos.x);
            pos.y = Random.Range(minPos.y, maxPos.y);
            pos.z = -1;
        }
        else
        {
            pos.x = 0;
            pos.y = 0;
            pos.z = -1;
        }

        StartCoroutine(SpawnBanana());
    }

    public IEnumerator SpawnBanana()
    {
        yield return new WaitForSeconds(time);
        GameObject BananaObject = Instantiate(Banana, pos, Quaternion.identity);

        time = Random.Range(minTime, maxTime);
        if (!isBanana)
        {
            pos.x = Random.Range(minPos.x, maxPos.x);
            pos.y = Random.Range(minPos.y, maxPos.y);
            pos.z = -1;
        }
        else
        {
            Destroy(BananaObject.GetComponent<Rigidbody2D>());
            pos.x = 0;
            pos.y = 0;
            pos.z = -1;

            BananaObject.transform.position = new Vector3(0, 0, -1);
            BananaObject.transform.parent = this.transform;
            BananaObject.transform.localPosition = new Vector3(0, 0, -1);
        }
        StartCoroutine(SpawnBanana());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Banana")
        {
            Destroy(collision.gameObject);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
     
    }
}
