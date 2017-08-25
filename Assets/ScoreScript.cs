using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Textを操作するために[UnityEngine.UI]をusingする
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	// 初期値をインスペクタで設定/変更したいのでpublicで宣言
    public int initScore;
    int currentScore;
    Text scoreText;

	// Use this for initialization
	void Start () {
		currentScore = initScore;
		scoreText = this.GetComponent<Text>();

		 printScore(initScore);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // スコアを減点する関数
    public void subScore(int n) {
        currentScore -= n;
        printScore(currentScore);
    }
     
    // スコアを加点する関数
    public void addScore(int n) {
        currentScore += n;
        printScore(currentScore);
    }
     
    void printScore(int n) {
         //scoreText.textはstring型(文字列)を受け取るが、nはint型(整数)なのでパース
        scoreText.text = "Score: " + n.ToString();
    }
}
