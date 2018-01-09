using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour {

	public GameObject shell;
	public GameObject flameShell;
	public float shootPower;
	public Transform shootPos;
	public float shootCooldown;
	public float fireShootCooldown;

	private AudioSource audioSource;
	private LayerMask enemyLayer;
	private bool isWeaponReady = true;
	private bool isFireWeaponReady = true;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

	public void init(LayerMask enemyLayer) {
		this.enemyLayer = enemyLayer;
	}

	public void shootFire() {
		if (!isFireWeaponReady) return;

		GameObject newShell = Instantiate (flameShell, shootPos.position, shootPos.rotation) as GameObject;
		Rigidbody r = newShell.GetComponent<Rigidbody> ();
		Shell shellComponent = newShell.GetComponent<Shell> ();

		shellComponent.init (enemyLayer);
		r.velocity = shootPos.forward * shootPower;	

		audioSource.Play ();
		isFireWeaponReady = false;
		StartCoroutine (FireWeaponCoolDown());
	}

	public void shoot () {
		if (!isWeaponReady) return;

		GameObject newShell = Instantiate (shell, shootPos.position, shootPos.rotation) as GameObject;
		Rigidbody r = newShell.GetComponent<Rigidbody> ();
		Shell shellComponent = newShell.GetComponent<Shell> ();

		shellComponent.init (enemyLayer);
		r.velocity = shootPos.forward * shootPower;

		audioSource.Play ();
		isWeaponReady = false;
		StartCoroutine (WeaponCoolDown());
	}

	IEnumerator WeaponCoolDown() {
		yield return new WaitForSeconds (shootCooldown);
		isWeaponReady = true;
	}

	IEnumerator FireWeaponCoolDown() {
		yield return new WaitForSeconds (fireShootCooldown);
		isFireWeaponReady = true;
	}
}
