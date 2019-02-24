using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using akazukin_GameJam;

public class GameOverManager : MonoBehaviour
{
	[SerializeField] private string titleSceneName;

	// Use this for initialization
	void Start () 
	{

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
