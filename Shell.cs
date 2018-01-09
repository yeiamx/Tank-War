using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	public GameObject explosionEffect;
	public float destroyTimeUp;
	public float explosionForce;
	public float explosionRadius;
	public int damage;


	private LayerMask enemyMask;

	public void init(LayerMask enemyMask) {
		this.enemyMask = enemyMask;
	}

	void OnCollisionEnter() {
		GameObject effectObj = Instantiate (explosionEffect, transform.position, transform.rotation) as GameObject;
		Destroy (gameObject);
		Destroy (effectObj, destroyTimeUp);

		Collider[] cols = Physics.OverlapSphere (transform.position, explosionRadius, enemyMask);
		if (cols.Length > 0) {
			for (int i = 0; i < cols.Length; i++) {
				Rigidbody r = cols [i].GetComponent<Rigidbody> ();
				if (r != null) {
					r.AddExplosionForce (explosionForce, transform.position, explosionRadius);
				}

				Unit u = cols [i].GetComponent<Unit> ();
				if (u != null) {
					u.ApplyDamage (damage);
				}
			}
		}
	}
}
