using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGame : MonoBehaviour {

	public Animator anim;
	public GameObject games;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver(){
		anim.SetBool ("Over", true);
	}

	void OnMouseExit(){
		anim.SetBool ("Over", false);
	}

	void OnMouseDrag(){
		anim.SetBool ("Selected", true);
	}

	void OnMouseUp(){
		anim.SetBool ("Selected", false);
	}

	void OnMouseUpAsButton(){
		games.SetActive (true);
		this.gameObject.SetActive (false);
	}
}
