using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerScript : MonoBehaviour {

	// スコア加算処理のためpublic宣言
	public GameObject scoreText;
    ScoreScript scoreS;


	// Use this for initialization
	void Start () {
		// ScoreTextに指定してあるスクリプトを取得
		scoreS = scoreText.GetComponent<ScoreScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 接触イベントハンドラ
	void OnCollisionEnter ( Collision colObject ) {
		/* 
			接触した相手オブジェクトに設定してあるタグ名が"Coin"ならそのオブジェクトを消す
			タグではなくオブジェクト名で判定も可能だが、今回のようにprefabをInstantiate()した場合
			オブジェクト名は[オブジェクト名(clone)]となってしまう
			応用で、異なるオブジェクトを例えば[Enemy]等のタグで関連付けることも可能
		*/
		if ( colObject.gameObject.tag == "Coin" ) {
			Destroy(colObject.gameObject);
			scoreS.addScore(2);
		}
	}
}
