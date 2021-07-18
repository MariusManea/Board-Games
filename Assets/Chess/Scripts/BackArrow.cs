using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackArrow : MonoBehaviour {

	public Animator anim;
	public GameObject menuCamera, mainCamera;

	// Use this for initialization
	void Start () {
		menuCamera = GameObject.Find ("NewGameButton").GetComponent<NewGameButton>().menuCamera;
		mainCamera = GameObject.Find ("NewGameButton").GetComponent<NewGameButton>().mainCamera;
	}

	// Update is called once per frame
	void Update () {

	}

	void BackToMainMenu(){
		GameObject.Find ("ContinueButton").GetComponent<ContinueButton> ().inPlay = true;
		GameObject.Find ("ContinueButton").GetComponent<ContinueButton> ().table = GameObject.Find ("Table");
		mainCamera.SetActive (false);
		menuCamera.SetActive (true);
		GameObject.Find ("Table").SetActive (false);
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
		BackToMainMenu ();
	}
}
