using UnityEngine;

[CreateAssetMenu(menuName ="Cards/Plant Card", fileName ="New Plant Card")]
public class MonkeyCardScriptableObject : ScriptableObject
{
    public Texture plantIcon;
    public GameObject Bullet;
    public Sprite plantSprite;
    public LayerMask zombieLayer;
    public int cost;
    public float cooldown;
    public bool isBananaFarmer;
    public BananaSpawner sunSpawnerTemplate;
    public float health;
    public float damage;
    public float range;
    public float speed;
    public float fireRate;

    public Vector2 size;
}
