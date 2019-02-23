using UnityEngine;
using UnityEngine.SceneManagement;

namespace akazukin_GameJam
{
	public class LoadScene : MonoBehaviour
	{

		public void LoadStart(string loadSceneName)
		{
			SceneManager.LoadScene(loadSceneName);
		}
	} 	

}