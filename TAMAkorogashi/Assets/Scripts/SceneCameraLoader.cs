using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor;
using UnityEngine;

public class SceneCameraLoader : EditorWindow
{
	private GameObject systemObject;
	static SceneCameraParameter sceneCameraParameter;
	
	string systemNameTextField = "";

	private int targetCam = 0;
	private string[] camNames = new string[0];

	// メニューのWindowにEditorExという項目を追加。
	[MenuItem("Window/SceneCameraLoder")]
	static void Open()
	{
		GetWindow<SceneCameraLoader>( "SceneCameraLoder" );
	}
 
	// Windowのクライアント領域のGUI処理を記述
	void OnGUI()
	{
		systemNameTextField = EditorGUILayout.TextField( "SystemName", systemNameTextField );
		if (GUILayout.Button("SetCameras"))
		{
			getCameras(systemNameTextField);
		}
		GUILayout.BeginHorizontal();
		{
			targetCam = EditorGUILayout.Popup( "TargetCam",targetCam,getCamNames() );
			
		}
		if (GUILayout.Button("AttachPosition!"))
		{
			setCameraPos();
		}
	}

	void getCameras(string sysName)
	{
		systemObject = GameObject.Find(sysName);

		if (systemObject == null)
		{
			Debug.LogError("エラー！Hierarchy上に\""+sysName+"\"が存在しないか、名前が間違っています");
			return;
		}

		if (systemObject.GetComponent<SceneCameraParameter>() == null)
		{
			Debug.LogError("エラー！\""+sysName+"\"に\"SceneCameraParameter\"がアタッチされてないみたいです");
			return;
		}

		sceneCameraParameter = systemObject.GetComponent<SceneCameraParameter>();
		sceneCameraParameter.setCameraObject();
		
		Debug.Log(sceneCameraParameter._cameras.Length +"Cameras set!");
	}
	
	void setCameraPos()
	{
		if (sceneCameraParameter == null)
		{
			Debug.LogError("エラー！SetCameraしてください");
			return;
		}

		if (camNames[targetCam] == "none")
		{
			Debug.LogError("エラー！カメラが見つからなかったです");
			return;
		}

		var sceneViewCamTransform = SceneView.lastActiveSceneView.camera.gameObject.transform;
		var sceneViewPos = sceneViewCamTransform.position;
		var sceneViewRotate = sceneViewCamTransform.rotation;
		GameObject _targetCam = GameObject.Find(camNames[targetCam]);
		
		_targetCam.transform.position = sceneViewPos;
		_targetCam.transform.rotation = sceneViewRotate;

	}

	string[] getCamNames()
	{
		if (sceneCameraParameter == null)
		{
			return new string[]{"none"};
		}
		var size = sceneCameraParameter._cameras.Length;

		if (sceneCameraParameter == null || size < 1)
		{
			return new string[]{"none"};
		}
		
		Array.Resize(ref camNames, size);
		for (int i = 0; i < size; i++)
		{
			if (sceneCameraParameter._cameras[i] != null)
			{
				camNames[i] = sceneCameraParameter._cameras[i].name;	
			}
			else
			{
				camNames[i] = "none";
			}
		}
		
		return camNames;
	}


}
