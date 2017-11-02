using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWall : MonoBehaviour {

	private Animator arenaAnimator;

	// Use this for initialization
	void Start () {
		GameObject arena = transform.parent.gameObject;
		arenaAnimator = arena.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		arenaAnimator.SetBool ("IsLowered", true);
	}

	void OnTriggerExit(Collider collider) {
		arenaAnimator.SetBool ("IsLowered", false);
	}
}
