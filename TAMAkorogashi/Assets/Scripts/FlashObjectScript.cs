using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using akazukin_GameJam;
public class FlashObjectScript : MonoBehaviour
{
	[SerializeField] private KeyCode testTrigger;
	[SerializeField] private KeyCode selectTrigger;
	[SerializeField] private GameObject FlashObject;
	[SerializeField] private bool StartAuto;
	[SerializeField] private float WaitTime;
	[SerializeField] private AudioSource _audioSource;

	[SerializeField] private string CharacterSelectSceneName;
	private LoadScene _loadScene;

	private bool isDone;


	// Use this for initialization
	void Start () 
	{
/*		if (StartAuto)
		{
			_audioSource.Play();
			StartCoroutine("SelectFlash");

		}*/
		_loadScene = new LoadScene();
		StartCoroutine(Flash());

	}
	
	// Update is called once per frame
	void Update () 
	{
/*
		if ( && !StartAuto)
		{
			StopCoroutine("Flash");
			_audioSource.Play();
			StartCoroutine("SelectFlash");
			
		}
*/



	}

	public void OnClick()
	{
		if (isDone)
		{
			return;
		}
		
		StopCoroutine("Flash");
		FlashObject.SetActive(true);
		isDone = true;
		if (_audioSource != null)
		{
			_audioSource.Play();	
		}
		StartCoroutine("SelectFlash");

	}
	
	
	private IEnumerator Flash()
	{
		while (true)
		{
			//Debug.Log("false");
			FlashObject.SetActive(false);
			yield return new WaitForSeconds(WaitTime);
			//Debug.Log("true");
			FlashObject.SetActive(true);
			yield return new WaitForSeconds(WaitTime);

		}
	}
	
	private IEnumerator SelectFlash()
	{
		int flashcount=0;
		while (flashcount<10)
		{
			flashcount += 1;
			//Debug.Log("false");
			FlashObject.SetActive(false);
			yield return new WaitForSeconds(WaitTime/10);
			//Debug.Log("true");
			FlashObject.SetActive(true);
			yield return new WaitForSeconds(WaitTime/10);
			
		}
		
		_loadScene.LoadStart(CharacterSelectSceneName);
		yield break;
	}


}
