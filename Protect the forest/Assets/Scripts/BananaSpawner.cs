using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
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
        pos.x = Random.Range(minPos.x, maxPos.x);
        pos.y = Random.Range(minPos.y, maxPos.y);
        pos.z = -1;
        StartCoroutine(SpawnBanana());
    }

    public IEnumerator SpawnBanana()
    {
        yield return new WaitForSeconds(time);
        Instantiate(Banana, pos, Quaternion.identity);

        time = Random.Range(minTime, maxTime);
        pos.x = Random.Range(minPos.x, maxPos.x);
        pos.y = Random.Range(minPos.y, maxPos.y);
        pos.z = -1;
        time = Random.Range(minTime, maxTime);
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
