using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Tank2 : Unit {

	public float moveSpeed;
	public float rotateSpeed;

	private TankWeapon tankWeapon;
	private LayerMask enemyLayer;
	// Use this for initialization
	void Start () {
		base.Start ();
		enemyLayer = LayerManager.getEnemyLayer (team);
		tankWeapon = GetComponent <TankWeapon>();
		tankWeapon.init (enemyLayer);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//可以把这两个值看成是按下特定键后的力度。 一个axis对应两个键的两个力度 正好相反。 所以我们写好对应的键，直接在做平移和旋转时乘上对应键力度即可。
		//按下某个键 其对应的力度开始发生变化，至少不是0 SO translate or rotate将不再接受一个0向量 将会发生对应的移动。于此同时 移动的大小由于受到力度大小的控制
		//(按一个键 其力的绝对值平滑过渡到1) 所以移动速度还会呈现出加速度的感觉。
		float horizontal = Input.GetAxis ("Horizontal2");
		float vertical = Input.GetAxis ("Vertical2");
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * vertical);
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);

		if (Input.GetKeyDown (KeyCode.L)) {
			tankWeapon.shoot ();
		}

		if (Input.GetKeyDown (KeyCode.K) && fire) {
			//Debug.Log ("shoot fire");
			tankWeapon.shootFire ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//触发器//碰到fire
		if (other.gameObject.tag == "flame")
		{
			//销毁碰到的对象
			Destroy(other.gameObject);
			//同时把fire设置为true
			fire = true;
		}
	}
}
