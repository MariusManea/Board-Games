using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour {

	public Animator anim;
	public bool inPlay;
	public GameObject menuCamera, mainCamera, table;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Continue(){
		table.SetActive (true);
		menuCamera.SetActive (false);
		mainCamera.SetActive (true);
	}

	void OnMouseOver(){
		if (inPlay) {
			anim.SetBool ("Over", true);
		}
	}

	void OnMouseExit(){
		if (inPlay) {
			anim.SetBool ("Over", false);
		}
	}

	void OnMouseDrag(){
		if (inPlay) {
			anim.SetBool ("Selected", true);
		}
	}

	void OnMouseUp(){
		if (inPlay) {
			anim.SetBool ("Selected", false);
		}
	}

	void OnMouseUpAsButton(){
		if (inPlay) {
			Continue ();
		}
	}
}
