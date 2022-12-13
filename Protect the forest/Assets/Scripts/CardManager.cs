using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public GameObject UI;
    public SlotsManagerCollider colliderName;
    SlotsManagerCollider prevName;
    public MonkeyCardScriptableObject plantCardScriptableObject;
    public Sprite plantSprite;
    public GameObject plantPrefab;
    public bool isOverCollider = false;
    GameObject plant;
    bool isHoldingPlant;

    public Image refreshImage;

    public bool isCoolingDown;
    [Tooltip("X: Max Height, Y: Min Height")]
    public Vector2 height;

    public void OnDrag(PointerEventData eventData)
    {


        if (isHoldingPlant)
        {
            //Take a gameObject
            plant.GetComponent<SpriteRenderer>().sprite = plantSprite;

            if (prevName != colliderName || prevName == null)
            {
                if (!colliderName.isOccupied)
                {
                    plant.transform.position = new Vector3(0, 0, -1);
                    plant.transform.localPosition = new Vector3(0, 0, -1);
                    isOverCollider = false;
                    if (prevName != null)
                    {
                        prevName.plant = null;
                    }
                    prevName = colliderName;
                }
            }
            else
            {
                if (!colliderName.isOccupied)
                {
                    plant.transform.position = new Vector3(0, 0, -1);
                    plant.transform.localPosition = new Vector3(0, 0, -1);
                }
            }

            if (!isOverCollider)
            {
                plant.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isCoolingDown)
        {
            return;
        }

        if (GameObject.FindObjectOfType<GameManager>().SunAmount >= plantCardScriptableObject.cost)
        {
            isHoldingPlant = true;
            Vector3 pos = new Vector3(0, 0, -1);
            plant = Instantiate(plantPrefab, pos, Quaternion.identity);
            plant.GetComponent<MonkeyManager>().thisSO = plantCardScriptableObject;
            plant.GetComponent<MonkeyManager>().isDragging = true;
            plant.transform.localScale = plantCardScriptableObject.size;
            plant.GetComponent<SpriteRenderer>().sprite = plantSprite;

            plant.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Debug.Log("Not enough sun!");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isCoolingDown)
        {
            return;
        }

        if (isHoldingPlant)
        {
            if (colliderName != null && !colliderName.isOccupied)
            {
                GameObject.FindObjectOfType<GameManager>().DeductSun(plantCardScriptableObject.cost);
                isHoldingPlant = false;
                colliderName.isOccupied = true;
                plant.tag = "Untagged";
                plant.transform.SetParent(colliderName.transform);
                plant.transform.position = new Vector3(0, 0, -1);
                plant.transform.localPosition = new Vector3(0, 0, -1);
                plant.AddComponent<BoxCollider2D>();
                plant.AddComponent<CircleCollider2D>();
                plant.GetComponent<CircleCollider2D>().isTrigger = true;

                plant.GetComponent<MonkeyManager>().isDragging = false;
                if (plantCardScriptableObject.isBananaFarmer)
                {
                    BananaSpawner sunSpawner  = plant.AddComponent<BananaSpawner>();
                    sunSpawner.isBananaFarmer = true;
                    sunSpawner.minTime = plantCardScriptableObject.sunSpawnerTemplate.minTime;
                    sunSpawner.maxTime = plantCardScriptableObject.sunSpawnerTemplate.maxTime;
                    sunSpawner.banana = plantCardScriptableObject.sunSpawnerTemplate.banana;
                }


                //Disable plant before cooldown finished
                StartCoroutine(cardCooldown(plantCardScriptableObject.cooldown));
            }
            else
            {
                isHoldingPlant = false;
                Destroy(plant);
            }
        }
    }

    public IEnumerator cardCooldown(float cooldownDuration) 
    {
        isCoolingDown = true;

        for (float i = height.x; i <= height.y; i++)
        {
            refreshImage.rectTransform.anchoredPosition = new Vector3(3, i,0);
            yield return new WaitForSeconds(cooldownDuration / height.y);
        }
        isCoolingDown = false;
    }

    public void StartRefresh()
    {
        StartCoroutine(cardCooldown(plantCardScriptableObject.cooldown));
    }
}
