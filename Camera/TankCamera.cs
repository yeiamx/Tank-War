﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCamera : MonoBehaviour {
	 
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}

	void LateUpdate () {
		if (target == null) return;
		transform.position = target.position;		
	}
}
