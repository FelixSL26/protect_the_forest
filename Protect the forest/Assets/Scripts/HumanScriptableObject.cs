using UnityEngine;

[CreateAssetMenu(menuName = "Entities/Zombies", fileName = "New Zombie")]
public class HumanScriptableObject : ScriptableObject
{
	public GameObject zombieDefault;
	public GameObject zombieAccessory;

	public float accessoryHealth;
	public float zombieHealth;
	public float zombieHandHealth;
	public float zombieDamage;
	public float zombieSpeed;
	public float attackInterval;
}