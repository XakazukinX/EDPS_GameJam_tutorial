using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using akazukin_GameJam;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	[SerializeField] private string titleSceneName;

	[SerializeField] private ScoreCounter _scoreCounter;

	[SerializeField] private Text scoreText;
	// Use this for initialization
	void Start () 
	{
		_scoreCounter.scoreStop();
		var resultScore = (float)((int) (_scoreCounter.getScore() * 100));
		_scoreCounter.setScore(resultScore);
		scoreText.text = resultScore.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			LoadScene loadScene = new LoadScene();
			
			loadScene.LoadStart(titleSceneName);
		}
	}
	
	
}
