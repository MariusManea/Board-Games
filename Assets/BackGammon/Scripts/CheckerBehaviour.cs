using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerBehaviour : MonoBehaviour {

	public bool type; // type = false = white / type = true = black
	public int point, place;
	public BTableBehaviour table;
	public GameObject guest;
	// Use this for initialization
	void Start () {
		table = GameObject.Find ("Table").GetComponent<BTableBehaviour> ();
	}

	void Positionate() {
		Vector3 pos = table.table.point [point].transform.GetChild (place).transform.position;
		pos.z = -2;
		this.transform.position = pos;
	}
		

	// Update is called once per frame
	void Update () {
		Positionate ();
		guest = table.table.point [point];
		if (place == table.table.checkers [point] - 1 && type == table.turn) {
			GetComponent<Animator> ().SetBool ("Selected", guest.GetComponent<PointBehaviour> ().selected);
		}
	}
}
