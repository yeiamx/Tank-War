using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team{
	Red, Blue, Green
}

public class Unit : MonoBehaviour {
	public int health ;
	public GameObject deadEffect;
	public Team team;
	public bool fire = false;

	private int curHealth;
	

	public void Start() {
		curHealth = health;
	}

	public void ApplyDamage(int damage) {
		if (curHealth > damage) {
			curHealth -= damage;
		} else {
			Destruct ();
		}
	}

	public void Destruct() {
		if (deadEffect != null) {
			Instantiate (deadEffect, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}

	public int getCurrentHealth() {
		return curHealth;
	}

}
