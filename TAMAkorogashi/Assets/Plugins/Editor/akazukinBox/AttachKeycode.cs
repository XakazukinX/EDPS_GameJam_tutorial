using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using Object = UnityEngine.Object;

public class AttachKeycode : EditorWindow
{
	private Object targetScript;
	private Object[] targetKeyCodeFields;

	private bool isRunningKeyCheck;

	private FieldInfo nowSelectInfo;
	
	[MenuItem("Window/akazukinEditor/AttachKeyCode")]
	static void Open()
	{
		GetWindow<AttachKeycode>();
	}
	
	void OnGUI()
	{
		//targetScriptにアタッチできるようにする。
		targetScript = EditorGUILayout.ObjectField("targetObject",targetScript,typeof(MonoBehaviour),true );
		
		//イベント
		var e = Event.current;

		//targetScriptが空っぽだったら何もしない。
		if (targetScript == null)
		{
			return;
		}

		//fieldを拾ってくる。
		FieldInfo[] infoArray = getKeyCodeFields(targetScript);
		
		foreach (FieldInfo info in infoArray)
		{
			GUILayout.BeginHorizontal();
			
			EditorGUILayout.LabelField( info.Name + ": " + info.GetValue(targetScript));
			//ボタンをクリックすると入力受付が開始される。
			if(GUILayout.Button("Change This KeyCode"))
			{
				isRunningKeyCheck = true;
				nowSelectInfo = info;
				Debug.Log("Key Input....");
				
			}
			
			GUILayout.EndHorizontal();
			//Debug.Log(info.Name + ": " + info.GetValue(targetScript));
		}
		
		GUILayout.BeginHorizontal();
		
		EditorGUILayout.LabelField("");
		
		GUILayout.EndHorizontal();
		
		//キャンセルボタン。入力待ち状態をキャンセルできる。
		if (GUILayout.Button("Cancel Change"))
		{
			isRunningKeyCheck = false;
			Debug.Log("Cancel Change KeyCode!");
		}
		
		//入力受付。
		if (e.type == EventType.KeyUp && isRunningKeyCheck)
		{
			//一番最後にボタンを押した対象のKeyCodeの値を変更する。
			nowSelectInfo.SetValue(targetScript,e.keyCode);
			isRunningKeyCheck = false;
			Debug.Log(nowSelectInfo.Name + "Key is Change for" +e.keyCode+" !");
		}
	}


	//KeyCode型のフィールドだけを拾う
	private FieldInfo[] getKeyCodeFields(Object _targetScript)
	{
		//BindingFlagを指定
		BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		//targetScriptから対象となるfieldを取得する。
		FieldInfo[] _infoArray = _targetScript.GetType().GetFields(bindingFlags);
		//返り値用
		List<FieldInfo> resultList = new List<FieldInfo>();
		FieldInfo[] resultField = new FieldInfo[_infoArray.Length];

		//型がKeyCodeのやつだけをresultListに格納していく。
		for (int i = 0; i < _infoArray.Length; i++)
		{
			if (_infoArray[i].FieldType == typeof(KeyCode)) 
			{
				resultList.Add(_infoArray[i]);
			}
		}
		//Listを配列にする。
		resultField = resultList.ToArray();		
		return resultField;
	}

	
}
