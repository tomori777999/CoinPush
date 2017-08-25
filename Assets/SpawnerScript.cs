using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	float moveSpeed = 2.0f;
	Rigidbody rb;
	float width;

	// publicメンバはインスペクタに表示される
	public GameObject coin;
	public GameObject leftWall;
    public GameObject rightWall;
    float leftWallPositionX;
    float rightWallPositionX;

	// scoreText(とScoreScript)をこのスクリプトから操作するためにpublic宣言
    public GameObject scoreText;
	// 通常のクラスのようにScriptクラス名で型宣言
	// scoreTextに含まれるScoreScriptを指定するのでこちらは非public
    ScoreScript scoreS;



	// Use this for initialization
	void Start () {
		// このオブジェクトのコンポーネントを操作するために[GetComponent<コンポーネント名>()]で取得
		rb = this.GetComponent<Rigidbody>();

		// このオブジェクトの幅を取得
		width = this.GetComponent<Renderer>().bounds.size.x;

		// 移動範囲制御のため壁のx座標取得
		leftWallPositionX = leftWall.transform.position.x;
        rightWallPositionX = rightWall.transform.position.x;

		// scoreTextに指定しているScoreScript型コンポーネントを取得
		scoreS = scoreText.GetComponent<ScoreScript>();
	}
	
	// Update is called once per frame
	void Update () {
		// Inputは入力関連,その中のGetAxis()で矢印キー入力(PC)の受付
		// 引数は["Horizontal"](左右キー) or ["Vertical"](上下キー) のいずれか
		// Rigidbodyの[Is Kinematic]をONにすると動かなかった・・要検証
		float x = Input.GetAxis("Horizontal");

		Vector3 direction = new Vector3(x, 0, 0);

		// verocityで移動速度を決定
		rb.velocity = direction * moveSpeed;

		// Mathf.Clampで値の範囲を設定できる第1引数に対象プロパティ,第二引数に最小値,第三引数に最大値を指定
        Vector3 currentPosition = this.transform.position;
        currentPosition.x = Mathf.Clamp
			(
				currentPosition.x,
				leftWallPositionX + width / 2,
				rightWallPositionX - width / 2
			);
        this.transform.position = currentPosition;

		// GetKeyDown("key名")で特定のキー入力を判定,GetKey("key名")なら入力され続ける間判定し続ける
		// Instantiate()でprefab化したGameObjectをインスタンス化
		if ( Input.GetKeyDown("space") ) {
			Instantiate(coin, this.transform.position, this.transform.rotation);
			// Scoreをマイナス1
			scoreS.subScore(1);
		}
	}
}
