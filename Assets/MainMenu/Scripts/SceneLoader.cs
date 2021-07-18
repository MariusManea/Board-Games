using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public int sceneIndex;
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

	void OnMouseDrag(){
		anim.SetBool ("Selected", true);
	}

	void OnMouseUp(){
		anim.SetBool ("Selected", false);
	}

	void OnMouseUpAsButton() {
		SceneManager.LoadScene (sceneIndex, LoadSceneMode.Single);
	}
}
