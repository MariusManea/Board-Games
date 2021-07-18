using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehaviour : MonoBehaviour {

	public int index;
	public BTableBehaviour table;
	public bool selected, active, host;
	public GameObject[] checkers;
	// Use this for initialization
	void Start () {
		int.TryParse(this.name,out index);
		table = GameObject.Find ("Table").GetComponent<BTableBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject != table.selectedPoint) {
			selected = false;
		}
		if (table.table.checkers [index] > 0) {
			host = (table.table.wOccupied [index] && !table.turn) || (table.table.bOccupied [index] && table.turn);
		} else {
			host = false;
		}
		GetComponent<Animator> ().SetBool ("Active", active);
	}

	void OnMouseDown() {
		if (host) {
			selected = !selected;
			if (this.gameObject == table.selectedPoint) {
				table.selectedPoint = null;
			} else {
				table.selectedPoint = this.gameObject;
			}
		}
	}

}
