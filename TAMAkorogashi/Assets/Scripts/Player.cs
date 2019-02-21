using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	// speedを制御する
	[SerializeField] private float speed = 10;
	private Rigidbody rigidbody;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		// xとzにspeedを掛ける
		rigidbody.AddForce(x * speed, 0, z * speed);
	}
}
