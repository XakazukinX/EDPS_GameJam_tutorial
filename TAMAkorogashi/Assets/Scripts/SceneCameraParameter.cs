using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCameraParameter : MonoBehaviour
{

	[SerializeField] private Camera[] cameras;

	[System.NonSerialized] public Camera[] _cameras;


	public void setCameraObject()
	{
		_cameras = cameras;
	}
}
