using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour {

	public float timeBetweenAttacks = 1f;
	public int attackDamage =10;

	Animator anim;
	GameObject player;
	PlayerLife PlayerLife;
	EnemyLife enemyHealth;
	bool playerInRange;
	float timer;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		PlayerLife = player.GetComponent<PlayerLife> ();
		enemyHealth = GetComponent<EnemyLife> ();
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) 
		{
			Attack ();
		}

		if(PlayerLife.currentHealth <= 0) 
		{
			anim.SetTrigger ("PlayerDead");
		}
	}

	void Attack ()
	{
		timer = 0f;
		if (PlayerLife.currentHealth > 0) {
			PlayerLife.TakeDamage (attackDamage);
		}
	}
}
