using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaviour : MonoBehaviour {

	public bool host, selected, active, moveHere;
	public TableBehaviour table;
	public GameObject guest;

	// Use this for initialization
	void Start () {
		table = GameObject.Find ("Table").GetComponent<TableBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () { 
		if(guest){
			if (guest.transform.parent.name == "WhitePieces") {
				host = !table.turn;
			} else {
				host = table.turn;
			}
		}
		if (host) {
			GetComponent<BoxCollider2D> ().enabled = true;
			GetComponent<Animator> ().SetBool ("Selected", selected);
			GetComponent<Animator> ().SetBool ("Active", false);
		} else {
			GetComponent<BoxCollider2D> ().enabled = active;
			GetComponent<Animator> ().SetBool ("Active", active);
		}
	}

	void OnMouseDown () {
		if (host && !table.transformation) {
			selected = !selected;
			if (table.selectedPiece) {
				table.selectedPiece.GetComponent<SquareBehaviour> ().selected = false;
				for (int i = 0; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						table.table [i].rows [j].GetComponent<SquareBehaviour> ().active = false;
					}
				}
				table.selectedPiece = null;
			}
			if (selected) {
				table.selectedPiece = this.gameObject;
			}
		}
		if (active) {
			moveHere = true;
			table.move = true;
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					table.table [i].rows [j].GetComponent<SquareBehaviour> ().active = false;
				}
			}
			table.selectedPiece = null;
		}
	}
}
