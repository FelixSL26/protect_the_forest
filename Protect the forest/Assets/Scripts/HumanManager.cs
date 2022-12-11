using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public HumanScriptableObject[] zombieScriptableObjects;
    public HumanScriptableObject selectedSO;
    public float timeInterval;
    public bool randomizeTimes;
    public float minTime;
    public float maxTime;
    public Transform[] columns;
    public int selectedColumns;

    private void Start()
    {
        StartCoroutine(ZombieSpawn());
    }

    public IEnumerator ZombieSpawn()
    {
        timeInterval = randomizeTimes ? Random.Range(minTime, maxTime) : timeInterval;

        yield return new WaitForSeconds(timeInterval);
        //Choose zombie
        selectedSO = zombieScriptableObjects[Random.Range(0, zombieScriptableObjects.Length)];

        //Spawn zombies
        int columnID = Random.Range(0, columns.Length);
        GameObject zombie = Instantiate(selectedSO.zombieDefault, columns[columnID]);

        zombie.GetComponent<HumanController>().thisZombieSO = selectedSO;

        zombie.transform.SetParent(columns[columnID]);
        zombie.transform.position = new Vector3(0, 0, -1);
        zombie.transform.localPosition = new Vector3(0, 0, -1);

        if (selectedSO.zombieAccessory != null)
        {
            GameObject accessory = Instantiate(selectedSO.zombieAccessory, zombie.transform);
            zombie.GetComponent<HumanController>().accessory = accessory;
            zombie.GetComponent<HumanController>().zombieAccessories = accessory.GetComponent<HumanAccessoriesManager>();
            zombie.GetComponent<HumanController>().zombieAccessories.accessoryHealth = selectedSO.accessoryHealth;
            zombie.GetComponent<HumanController>().zombieAccessories.accessoryHealthCurrent = selectedSO.accessoryHealth;
        }

        StartCoroutine(ZombieSpawn());
    }
}
