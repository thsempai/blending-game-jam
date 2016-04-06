using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeadScreen : MonoBehaviour {

    // Use this for initialization
    void Start () {
    Cursor.visible = true;
    Screen.lockCursor = false;
    Text scoreText = GetComponent<Text>();
    int score= PlayerPrefs.GetInt("score");
    scoreText.text += score.ToString("0000000");

    int hightestScore = PlayerPrefs.GetInt("hightest score");
    if(score > hightestScore){
        hightestScore = score;
        PlayerPrefs.SetInt("hightest score", score);
        }
    scoreText.text += "\n\nHightest score:\n\n" + hightestScore.ToString("0000000");
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
