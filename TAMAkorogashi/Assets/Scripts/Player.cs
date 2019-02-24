using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Accel
{
	private Rigidbody rigidbody;
	private PhotonView _photonView;
	[Header("Playerの基本情報")]
	[SerializeField] private float speed = 0.23f;

	[SerializeField] private string gameOverUIName;

/*	[SerializeField] private int Life;*/
	
	private void Start()
	{
		//Componentの取得
		_photonView = GetComponent<PhotonView>();
		rigidbody = GetComponent<Rigidbody>();
		base.Start();

	}
	
	void FixedUpdate ()
	{
		
		//自分のオブジェクトだった場合のみ操作。
		if (!_photonView.isMine)
		{
			return;
		}
		
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		//移動の計算
		rigidbody.velocity += new Vector3(x * speed * acceleration(), 0, z * speed * acceleration());
/*
		rigidbody.AddForce(x * speed * acceleration() , 0, z * speed * acceleration() );
*/
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Field")
		{
			GameObject.Find ("Canvas").transform.Find(gameOverUIName).gameObject.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}