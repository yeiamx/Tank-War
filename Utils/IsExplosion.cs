using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsExplosion : MonoBehaviour {

	public float explosionRadius;
	public float explosionForce;

	// Use this for initialization
	void Start () {
		Collider[] cols = Physics.OverlapSphere (transform.position, explosionRadius);
		if (cols.Length > 0) {
			for (int i = 0; i < cols.Length; i++) {
				Rigidbody r = cols [i].GetComponent<Rigidbody> ();
				if (r != null) {
					r.AddExplosionForce (explosionForce, transform.position, explosionRadius);
				}
			}
		}
	}

}
