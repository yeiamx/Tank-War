using UnityEngine;
using System.Collections;

public class EatableFlame : MonoBehaviour
{
	public GameObject eatableFlame;
	// Use this for initialization
	void Start ()
	{
		CreateFlame ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void CreateFlame() {
		float[,] positions = new float[7,2] {{-4.6f,15.4f}, {-15.8f, 5.23f}, {-26.9f,12.71f}, {12f,-12f}, {-12.1f,8.7f}, {-35f,-4f}, {0f, 2f}};
		int randKey1 = Random.Range (0,7);
		int randKey2 = Random.Range (0,7);

		eatableFlame.transform.position = new Vector3 (positions[randKey1,0], 0, positions[randKey1,1]);
		//Debug.Log("Create at :"+eatableFlame.transform.position+" and " + eatableFlame.transform.rotation);
		Instantiate (eatableFlame, eatableFlame.transform.position, eatableFlame.transform.rotation);

		eatableFlame.transform.position = new Vector3 (positions[randKey2,0], 0, positions[randKey2,1]);
		//Debug.Log("Create at :"+eatableFlame.transform.position+" and " + eatableFlame.transform.rotation);
		Instantiate (eatableFlame, eatableFlame.transform.position, eatableFlame.transform.rotation);
	}
}

