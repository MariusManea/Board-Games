using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour {

	public Animator anim;
	public GameObject table;
	public GameObject menuCamera, mainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NewGame(){
		if (GameObject.Find ("Table")) {
			DestroyImmediate (GameObject.Find ("Table"));
		}
		table = GameObject.Instantiate (Resources.Load ("Table")) as GameObject;
		table.name = "Table";
		menuCamera.SetActive (false);
		mainCamera.SetActive (true);

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
		NewGame ();
	}
}
