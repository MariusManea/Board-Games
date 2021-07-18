using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehaviour : MonoBehaviour {

	public Animator anim;
	public int dice;
	public float time;
	void Start () {
		time = Time.time - 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - time > 0.1f) {
			dice = Random.Range (1, 6);
			time = Time.time;
		}
		anim.SetInteger ("Dice", dice);
	}
}
