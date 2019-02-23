using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectButton : MonoBehaviour 
{
	enum CHARACTER_SELECT_BUTTON_TYPE
	{
		LEFT,  
		RIGHT, 
		SELECT,
	}
	
	[SerializeField] private CHARACTER_SELECT_BUTTON_TYPE _buttonType;

	[SerializeField] private CharacterSelectManager _characterSelectManager;



	// Use this for initialization
	void Start () 
	{
		//表示の初期化
		_characterSelectManager._characters[0].selected();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick()
	{
		if (_buttonType == CHARACTER_SELECT_BUTTON_TYPE.LEFT)
		{
			_characterSelectManager.clickLeftButton();
		}
		if (_buttonType == CHARACTER_SELECT_BUTTON_TYPE.RIGHT)
		{
			_characterSelectManager.clickRightButton();
		}
		if (_buttonType == CHARACTER_SELECT_BUTTON_TYPE.SELECT)
		{
			_characterSelectManager.clickSelectButton();
		}
	}
}
