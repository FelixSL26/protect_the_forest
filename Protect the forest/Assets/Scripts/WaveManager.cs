using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    public List<int> levelGoals;

    public Transform flagTransform;
    public GameObject flagPrefab;

    public Slider levelProgress;
    public static int currentHumanCount = 0;
    [SerializeField] int currentKills = 0;
    int nextGoal = 0;


    /// <summary>
    /// Key : goals, Value : index
    /// </summary>
    public Dictionary<int, int> goalsToIndex;

    public List<FlagsManager> flags;


    private void Awake()
    {
        goalsToIndex = new Dictionary<int, int>();
        flags = new List<FlagsManager>();
    }

    public void Start()
    {
        int i = 0;

        nextGoal = levelGoals[0];


        foreach (var item in levelGoals)
        {
            GameObject tempFlag = Instantiate(flagPrefab, flagTransform);
            flags.Add(tempFlag.GetComponent<FlagsManager>());

            goalsToIndex.Add(item, i);

            i++;
        }

        levelProgress.maxValue = levelGoals[levelGoals.Count - 1];

    }


    private void Update()
    {
        currentKills = currentHumanCount;
        levelProgress.value = currentKills;

        if (currentKills >= nextGoal)
        {
            flags[goalsToIndex[nextGoal]].Expand();

            nextGoal = levelGoals[levelGoals.IndexOf(nextGoal) + 1 < levelGoals.Count ? levelGoals.IndexOf(nextGoal) + 1 : 0];
        }

        if (currentKills >= 10)
        {
            SceneManager.LoadScene("Win");
            Debug.Log("win!");
            currentKills = 0;
            currentHumanCount = 0;
            Debug.Log(currentKills);
        }
    }





}
