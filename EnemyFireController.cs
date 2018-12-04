﻿using UnityEngine;
using System.Collections;

public class EnemyFireController : MonoBehaviour {

	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsForKill;
	public int damageToGive;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		if (player.transform.position.x < transform.position.x)
			speed = -speed;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			/*
			Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (pointsForKill);
			*/
			//other.GetComponent<EnemyHealthManager> ().GiveDamage (damageToGive);
			HealthManager.HurtPlayer(damageToGive);
		}
		if (other.tag == "Checkpoint")
			return;
		if (other.tag == "Coin")
			return;
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);

	}
}

