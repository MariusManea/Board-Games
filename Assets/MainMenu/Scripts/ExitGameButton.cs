﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour {

	public Animator anim;

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
		
	void OnMouseUpAsButton(){
		Application.Quit ();
	}
}