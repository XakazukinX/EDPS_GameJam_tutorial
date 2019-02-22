using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using akazukin_GameJam;
using Cinemachine;

public class Playergenerator : MonoBehaviour
{

	[SerializeField] private string playerObjectName = "Player";
	[SerializeField] private CinemachineVirtualCamera mainvcam;
	[SerializeField] private Vector3 firstPos = new Vector3(0,2,0);
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnJoinedRoom()
	{
		GameObject _player = PhotonNetwork.Instantiate (playerObjectName, firstPos, Quaternion.Euler (0, 0, 0), 0);
		CameraSetter cameraSetter = new CameraSetter();
		cameraSetter.setVcam(mainvcam,_player.transform);
	}
	
}
