﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public PlayerLife playerHealth;
	public float restartDelay = 5f;

	Animator anim;
	float restartTimer;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (playerHealth.currentHealth <= 0) {
			anim.SetTrigger ("GameOver");
			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				SceneManager.LoadScene(0);
			}
		}
	}

}
