using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour {

	[Header("加速に関する項目")]
	[SerializeField] private KeyCode accelKey;
	[SerializeField] private float accelWeight;
	[SerializeField] private float accelTime;
	private bool isAccel;
	
	[SerializeField] private float acceiInterval;
	private bool isInterval;

	private void Update()
	{
		//AccelKeyが入力されたときに加速が開始される。
		if (Input.GetKeyDown(accelKey) && !isAccel)
		{
			isAccel = true;
			StartCoroutine(accelTimeManagement());
/*
			Debug.Log("Accel!");
*/
		}
	}

	protected float acceleration()
	{
		//加速の処理
		//加速時でない、またはインターバル時間内であれば1.0fを返す。
		if (!isAccel || isInterval)
		{
			return 1.0f;
		}
		else
		{
			return accelWeight;
		}
	}
	
	//加速時間の管理コルーチン
	IEnumerator accelTimeManagement()
	{
		var _accelTime = accelTime;
		
		//加速時間の処理
		while (_accelTime>0)
		{
			_accelTime -= Time.deltaTime;
			yield return null;
		}
		
		isAccel = false;
		StopCoroutine(accelTimeManagement());
		
		//加速が終了したらインターバルのコルーチンを起こす
		isInterval = true;
		StartCoroutine(accelIntervalManagement());
	}
	
	//インターバルのコルーチン
	IEnumerator accelIntervalManagement()
	{
		yield return new WaitForSeconds(acceiInterval);
		isInterval = false;
		StopCoroutine(accelIntervalManagement());
	}
}