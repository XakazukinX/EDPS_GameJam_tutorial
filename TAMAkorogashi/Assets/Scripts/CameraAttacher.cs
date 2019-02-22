using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace akazukin_GameJam
{
	public class CameraSetter {

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}

		public void setVcam(CinemachineVirtualCamera vcam , Transform lookat)
		{
			vcam.LookAt = lookat;
		}
	}

}

