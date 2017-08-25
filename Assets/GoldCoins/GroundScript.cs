using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision colObject) {
		if ( colObject.gameObject.tag == "Coin" ) {
			Destroy(colObject.gameObject);
		}
	}
}
