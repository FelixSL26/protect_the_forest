using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public GameObject UI;
    public SlotsManagerCollider colliderName;
    SlotsManagerCollider prevName;
    public MonkeyCardScriptableObjects monkeyCardScriptableObjects;
    public Sprite monkeySprite;
    public GameObject monkeyPrefab;
    public bool isOverCollider = false;
    GameObject monkey;
    bool isHoldingBanana;



    public void OnDrag(PointerEventData eventData)
    {
        if (isHoldingBanana)
        {
            //take a gameObject
            monkey.GetComponent<SpriteRenderer>().sprite = monkeySprite;

            if (prevName != colliderName || prevName == null)
            {
                isOverCollider = false;
                if (prevName != null)
                {
                    prevName.monkey = null;
                }
                prevName = colliderName;

            }

            if (!isOverCollider)
            {
                monkey.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }


        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (GameObject.FindObjectOfType<GameManager>().BananaAmount >= monkeyCardScriptableObjects.cost)
        {
            isHoldingBanana = true;
            Vector3 pos = new Vector3(0, 0, -1);
            monkey = Instantiate(monkeyPrefab, pos, Quaternion.identity);
            monkey.GetComponent<SpriteRenderer>().sprite = monkeySprite;
            monkey.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Debug.Log("Not Enough Banana");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (colliderName != null && !colliderName.isOccupied)
        {
            if (isHoldingBanana)
            {
                GameObject.FindObjectOfType<GameManager>().DeductBanana(monkeyCardScriptableObjects.cost);
                isHoldingBanana = false;
                colliderName.isOccupied = true;
                monkey.tag = "Untagged";
                monkey.transform.SetParent(colliderName.transform);
                monkey.transform.position = new Vector3(0, 0, -1);
                monkey.transform.localPosition = new Vector3(0, 0, -1);

                if (monkeyCardScriptableObjects.isBanana)
                {
                    BananaSpawner bananaSpawner = monkey.AddComponent<BananaSpawner>();
                    bananaSpawner.isBanana = true;
                    bananaSpawner.minTime = monkeyCardScriptableObjects.bananaSpawnerTemplate.minTime;
                    bananaSpawner.maxTime = monkeyCardScriptableObjects.bananaSpawnerTemplate.maxTime;
                    bananaSpawner.Banana = monkeyCardScriptableObjects.bananaSpawnerTemplate.Banana;

                }
            }
            else
            {
                isHoldingBanana = false;
                Destroy(monkey);
            }
        }

    }


}
