using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HumanController : MonoBehaviour
{
    public HumanScriptableObject thisZombieSO;
    public HumanAccessoriesManager zombieAccessories;
    public float speed;
    public float health;
    public float handHealth;
    public float currentHealth;
    public GameObject accessory;
    public float accessoryHealth;
    public float damage;
    public float attackInterval;
    GameObject target;
    public bool isAttacking;

    public AudioClip damageAudio;

    public float damageDelay = 2f;

    bool isDying;
    bool incremented = false;

    private void Start()
    {
        speed = thisZombieSO.zombieSpeed;
        health = thisZombieSO.zombieHealth;
        accessoryHealth = thisZombieSO.accessoryHealth;
        damage = thisZombieSO.zombieDamage;
        handHealth = thisZombieSO.zombieHandHealth;
        attackInterval = thisZombieSO.attackInterval;
        currentHealth = health;
    }

    private void Update()
    {
        if (target == null)
        {
            isAttacking = false;
        }

        if (!isAttacking && !isDying)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            this.transform.position = this.transform.position;
        }


        if (currentHealth <= 0 && this.transform.childCount > 0)
        {
            isDying = true;

            if (!incremented)
            {
                incremented = true;
                WaveManager.currentHumanCount++;
            }

            //Dead
            //Add rigidbody 2d to head
            Transform head = this.transform.GetChild(0);

            head.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            head.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;

            head.SetParent(null);

            Destroy(head.gameObject, 1.5f);

            Destroy(this.GetComponent<Rigidbody2D>());

            foreach (var item in this.GetComponents<BoxCollider2D>())
            {
                Destroy(item);
            }

            Destroy(this.gameObject, 2f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.name);
        //Detect plant collisions
        if (collision.gameObject.tag == "Plant")
        {
            isAttacking = true;
            target = collision.gameObject;
            StartCoroutine(Attack());
        }
        else if (collision.gameObject.GetComponent<MonkeyManager>() != null)
        {
            isAttacking = true;
            target = collision.gameObject;
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
        isAttacking = false;
    }

    public IEnumerator Attack()
    {
        Debug.Log("Attacking...");
        //Attack Plant
        if (target != null)
        {
            target.GetComponent<MonkeyManager>().Damage(damage);
        }

        yield return new WaitForSeconds(attackInterval);
        StartCoroutine(Attack());
    }

    public void DealDamage(float amnt)
    {
        //Audio to play
        this.GetComponent<AudioSource>().PlayOneShot(damageAudio);

        currentHealth -= amnt;

        if (zombieAccessories != null)
        {
            zombieAccessories.TakeDamage(amnt);
        }

        StartCoroutine(DamageColor(this.gameObject.GetComponent<SpriteRenderer>()));

        foreach (Transform item in this.transform.GetComponentInChildren<Transform>())
        {
            StartCoroutine(DamageColor(item.gameObject.GetComponent<SpriteRenderer>()));   
        }
    }

    public IEnumerator DamageColor(SpriteRenderer spriteRenderer)
    {
        for(int i = 0; i <= 255; i+=10)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(i, i, i);
            }

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.1f);

        for (int i = 255; i <= 0; i-=10)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(i, i, i);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
