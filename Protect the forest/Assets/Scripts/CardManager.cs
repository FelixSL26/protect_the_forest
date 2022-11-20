using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public MonkeyCardScriptableObjects monkeyCardScriptableObjects;
    public Sprite monkeySprite;
    public GameObject monkeyPrefab;
    GameObject monkey;

    public void OnDrag(PointerEventData eventData)
    {
        //take a gameObject
        monkey.GetComponent<SpriteRenderer>().sprite = monkeySprite;


        monkey.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        monkey = Instantiate(monkeyPrefab, Vector3.zero, Quaternion.identity);
        monkey.GetComponent<SpriteRenderer>().sprite = monkeySprite;
        monkey.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Remove the gameObject
        //monkeySprite = null;
        Destroy(monkey);
    }


}
