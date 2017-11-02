using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public float destructTime = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initiate() {
		Invoke ("Destruct", destructTime);
	}

	private void Destruct() {
		Destroy(gameObject);
	}
}
