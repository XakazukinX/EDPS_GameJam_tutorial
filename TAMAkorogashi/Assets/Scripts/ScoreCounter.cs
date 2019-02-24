using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

	private float score;

	private bool isStop;
	// Use this for initialization
	void Start () {
		
	}

	private void FixedUpdate()
	{
		if (isStop)
		{
			return;
		}
		score += Time.deltaTime*10;
		Debug.Log(score);
	}

	public void scoreStop()
	{
		isStop = true;
	}

	public float getScore()
	{
		return score;
	}
}
