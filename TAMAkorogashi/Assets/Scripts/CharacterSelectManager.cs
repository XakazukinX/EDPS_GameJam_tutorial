using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using akazukin_GameJam;

public class CharacterSelectManager : MonoBehaviour
{
    private AudioSource _audioSource;
    //選択中のキャラクターインデックスをここに格納。
    private int selectNumber;
    
    [Header("遷移先のsceneの名前")]
    [SerializeField] private string mainSceneName = "MainScene";
    
    //それぞれのキャラクターのプロパティ。
    [Serializable]
    public class CharacterObject
    {
        public GameObject character;
        public GameObject characterPropertyUI;

        public void unSelected()
        {
            character.SetActive(false);
            characterPropertyUI.SetActive(false);
        }
        
        public void selected()
        {
            character.SetActive(true);
            characterPropertyUI.SetActive(true);
        }
    }

    [SerializeField] public CharacterObject[] _characters;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    //それぞれのボタンが押されたときの処理。
    public void clickLeftButton()
    {
        var beforeNum = selectNumber;
        selectNumber -= 1;
        characterChange(beforeNum);
    }

    public void clickRightButton()
    {
        var beforeNum = selectNumber;
        selectNumber += 1;
        characterChange(beforeNum);
    }
    
    public void clickSelectButton()
    {
        _audioSource.Play();
        Debug.Log(getSelectedCharacterName());
        Playergenerator.playerObjectName = getSelectedCharacterName();
        
        LoadScene loadScene = new LoadScene();
        loadScene.LoadStart(mainSceneName);
    }
    
    
    //Character切り替える関数。
    private void characterChange(int _beforeNum)
    {
        _audioSource.Play();
        selectNumber = Mathf.Clamp(selectNumber,0,2);
        //クリック前に表示されていたPlayerと同じindexであれば弾く。
        if (_beforeNum == selectNumber)
        {
            return;
        }
        _characters[_beforeNum].unSelected();
        _characters[selectNumber].selected();
    }
    
    private string getSelectedCharacterName()
    {
        //選択中のキャラクターオブジェクトの名前を拾ってきて返す。
        return _characters[selectNumber].character.name;
    }
    
}


