using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utils;

public class AITank : Unit {
	public float enemySearchRange;
	public ISRange attackRange;
	public ISRange stopRange;
	public float coreTimer;

	private GameObject enemy;
	private NavMeshAgent navMeshAgent;
	private TankWeapon tankWeapon;
	private LayerMask enemyLayer;
	private float currentStopDistance;
	private float currentAttackDistance;


	void Start() {
		base.Start ();
		enemyLayer = LayerManager.getEnemyLayer (team);
		tankWeapon = GetComponent<TankWeapon> ();
		tankWeapon.init (enemyLayer);

		navMeshAgent = GetComponent<NavMeshAgent> ();
		StartCoroutine (Timer());
	}

	void FixedUpdate() {
		if (enemy == null) {
			SearchEnemy ();
			return;
		}

		float distance = Vector3.Distance (enemy.transform.position, transform.position);

		if (distance > currentStopDistance) {
			navMeshAgent.SetDestination (enemy.transform.position);
		} else {
			navMeshAgent.ResetPath ();
			Vector3 dir = enemy.transform.position - transform.position;
			Quaternion wantedRotation = Quaternion.LookRotation (dir);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.fixedDeltaTime);
		}

		if (distance < currentAttackDistance) {
			tankWeapon.shoot ();
		}

	}

	IEnumerator Timer() {
		while (enabled) {
			currentStopDistance = ISMath.Random(stopRange);
			currentAttackDistance = ISMath.Random (attackRange);
			currentStopDistance = Mathf.Min (currentStopDistance, currentAttackDistance);

			SearchEnemy ();
			yield return new WaitForSeconds (coreTimer);
		}
	}

	public void SearchEnemy() {
		Collider[] cols = Physics.OverlapSphere (transform.position, enemySearchRange, enemyLayer);
		if (cols.Length > 0) {
			float minDis = Mathf.Infinity;
			float curDis;
			for (int i = 0; i < cols.Length; i++) {
				curDis = Vector3.Distance (cols [i].transform.position, transform.position);
				if (curDis < minDis) {
					enemy = cols [Random.Range (0, cols.Length)].gameObject;
					minDis = curDis;
				}
			}
		}
	}
}
