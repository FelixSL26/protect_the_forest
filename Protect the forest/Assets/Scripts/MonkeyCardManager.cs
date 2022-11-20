using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonkeyCardManager : MonoBehaviour
{
   // [Header("UI Parameters")]
   // public Image monkeyIconDisp;
    // public TMP_Text monkeyCostDisp;

    [Header("Cards Parameters")]
    public int amtOfCards;
    public MonkeyCardScriptableObjects[] monkeyCardSO;
    public GameObject cardPrefab;
    public Transform cardHolderTransform;

    [Header("Monkey Parameters")]
    public GameObject[] monkeyCards;
    public float cooldown;
    public int cost;
    public Sprite monkeyIcon;

    private void Start()
    {
        amtOfCards = monkeyCardSO.Length;
        monkeyCards = new GameObject[amtOfCards];

        for (int i = 0; i < amtOfCards; i++ )
        {
            AddMonkeyCard(i);
        }
    }

    public void AddMonkeyCard(int index)
    {
        GameObject card = Instantiate(cardPrefab, cardHolderTransform);

        CardManager cardManager = card.GetComponent<CardManager>();

        cardManager.monkeyCardScriptableObjects = monkeyCardSO[index];
        cardManager.monkeySprite = monkeyCardSO[index].monkeySprite;

        cardManager.UI = GameObject.FindGameObjectWithTag("Canvas");

        monkeyCards[index] = card;

        //getting variables
        monkeyIcon = monkeyCardSO[index].monkeyIcon;
        cost = monkeyCardSO[index].cost;
        cooldown = monkeyCardSO[index].cooldown;

        //updating UI
        card.GetComponentInChildren<Image>().sprite = monkeyIcon;
        card.GetComponentInChildren<TMP_Text>().text = "" + cost;
    }

}
