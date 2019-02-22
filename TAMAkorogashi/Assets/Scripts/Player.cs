using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	// speedを制御する
	[SerializeField] private float speed = 10;
	private Rigidbody rigidbody;
	private PhotonView _photonView;

	[SerializeField] private KeyCode accelKey;
	[SerializeField] private float accelWeight;
	[SerializeField] private float accelTime;
	private bool isAccel;
	
	[SerializeField] private float accelInterval;
	private bool isInterval;


	private void Start()
	{
		_photonView = GetComponent<PhotonView>();
		rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		
		if (!_photonView.isMine)
		{
			return;
		}
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		if (Input.GetKeyDown(accelKey) && !isAccel && !isInterval)
		{
			StartCoroutine(accelTimeManagement());
			isAccel = true;
			Debug.Log("Accel!");
		}

		if (isAccel)
		{
			// xとzにspeedを掛ける
			rigidbody.AddForce(x * speed * accelWeight, 0, z * speed * accelWeight);	
		}
		else
		{
			// xとzにspeedを掛ける
			rigidbody.AddForce(x * speed , 0, z * speed );
		}
		
	}

	IEnumerator accelTimeManagement()
	{
		var _accelTime = accelTime;
		while (_accelTime>0)
		{
			_accelTime -= Time.deltaTime;
			yield return null;
		}
		
		isAccel = false;
		StopCoroutine(accelTimeManagement());
		isInterval = true;
		StartCoroutine(accelIntervalManagement());
	}

	IEnumerator accelIntervalManagement()
	{
		yield return new WaitForSeconds(accelInterval);
		isInterval = false;
		StopCoroutine(accelIntervalManagement());
	}
}