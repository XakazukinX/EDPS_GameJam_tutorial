using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonSetUp : MonoBehaviour 
{

	static string GAME_VERSION = "Ver.1";
	private int testVal = 0;

	private PhotonView _photonView;

	[SerializeField] private string roomName;
	//------------------------------------------------------------------------------------------------------------------------------//
	void Start() 
	{
		_photonView = GetComponent<PhotonView>();

		PhotonNetwork.ConnectUsingSettings("0.0.1v");
		// アプリの起動と同時にPhotonCloudに接続
		Debug.Log("PhotonLogin: マスターサーバーに接続します");
		PhotonNetwork.gameVersion = GAME_VERSION;

	}
    
	public void OnConnectedToMaster() {

		Debug.Log("PhotonLogin: マスターサーバーに接続しました");
		Debug.Log("PhotonLogin: ルームに入室します");

		// ルームへの参加 or 新規作成
		PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), null);

	}

	public void OnJoinedRoom()
	{
		if (PhotonNetwork.isMasterClient)
		{
			Debug.Log("この端末はマスタークライアントです");
		}
		else
		{
			Debug.Log("この端末はマスタークライアントではありません");
		}
	}
    

	private void Update()
	{
		//Debug.Log(PhotonNetwork.room.Name);
		if (PhotonNetwork.isMasterClient)
		{
            
			//  Debug.Log("Master");
		}

		if (Input.GetKeyDown(KeyCode.F12))
		{
			if(!PhotonNetwork.isMasterClient)
				_photonView.RPC("test",PhotonTargets.All);  
		}
	}

	[PunRPC]
	private void test()
	{
		testVal += 1;
		Debug.Log(testVal);
	}
    
}