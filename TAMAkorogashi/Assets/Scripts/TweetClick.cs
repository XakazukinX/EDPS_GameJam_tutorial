using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetClick : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    
    public void OnClick()
    {
        var tweetText = "チュートリアルの玉転がしで"+_scoreCounter.getScore().ToString()+"点獲得しました！";
        Application.OpenURL("https://twitter.com/intent/tweet?text="+tweetText+"&hashtags=EDPS_201903_GameJam,akazukin_game");
    }
}
