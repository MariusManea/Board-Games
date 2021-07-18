using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKingBehaviour : MonoBehaviour {

	public GameObject position, transformWindow, leftRook, rightRook;
	public bool selected, leftCastling, rightCastling, check;
	public int X, Y;
	public TableBehaviour table;
	public CheckForAttack compute;

	// Use this for initialization
	void Start () {
		selected = false;
		check = false;
		leftCastling = true;
		rightCastling = true;
		table = GameObject.Find ("Table").GetComponent<TableBehaviour> ();

	}

	void PossibleMoves (){
		int[] x = new int[] { 1, 1, -1, -1, 1, -1, 0, 0 };
		int[] y = new int[] { 1, -1, 1, -1, 0, 0, 1, -1 };
		for (int i = 0; i < 8; i++) {
			if (X + x [i] >= 0 && X + x [i] < 8 && Y + y [i] >= 0 && Y + y [i] < 8) {
				if (!table.table [X + x [i]].wOccupied [Y + y [i]] && !table.table [X + x [i]].bAttacked [Y + y [i]]) {
					table.pTable = table.CopyTable(table.table);
					if (table.pTable [X + x [i]].bOccupied [Y + y [i]]) {
						table.pTable [X + x [i]].rows [Y + y [i]].GetComponent<SquareBehaviour> ().guest.SetActive (false);
					}
					table.pTable [X].wOccupied [Y] = false;
					table.pTable [X + x [i]].wOccupied [Y + y [i]] = true;
					compute.Compute (table.pTable);
					if (!table.pTable [X + x [i]].bAttacked [Y + y [i]]) {
						table.table [X + x [i]].rows [Y + y [i]].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
						table.wAble = true;
					}
					if (table.pTable [X + x [i]].bOccupied [Y + y [i]]) {
						table.pTable [X + x [i]].rows [Y + y [i]].GetComponent<SquareBehaviour> ().guest.SetActive (true);
					}
				}
			}
		}
		if (leftCastling) {
			if (!check) {
				if (!table.table [X].wOccupied [Y - 1] && !table.table [X].bOccupied [Y - 1] && !table.table [X].wOccupied [Y - 2] && !table.table [X].bOccupied [Y - 2] && !table.table [X].wOccupied [Y - 3] && !table.table [X].bOccupied [Y - 3]) {
					if (!table.table [X].bAttacked [Y - 1] && !table.table [X].bAttacked [Y - 2] && leftRook) {
						table.table [X].rows [Y - 2].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
						table.wAble = true;
					}
				}
			}
		}
		if (rightCastling) {
			if (!check) {
				if (!table.table [X].wOccupied [Y + 1] && !table.table [X].bOccupied [Y + 1] && !table.table [X].wOccupied [Y + 2] && !table.table [X].bOccupied [Y + 2]) {
					if (!table.table [X].bAttacked [Y + 1] && !table.table [X].bAttacked [Y + 2] && rightRook) {
						table.table [X].rows [Y + 2].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
						table.wAble = true;
					}
				}
			}
		}
		if (table.wTurnCheck) {
			table.wToCheck++;
		}
	}


	// Update is called once per frame
	void Update () {
		check = table.table [X].bAttacked [Y];
		if (position.GetComponent<SquareBehaviour> ().selected || table.wTurnCheck) {
			if (table.move) {
				for (int i = 0; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						if (table.table [i].rows [j].GetComponent<SquareBehaviour> ().moveHere) {
							if (leftCastling || rightCastling) {
								if (j == Y + 2) {
									rightRook.GetComponent<WhiteRookBehaviour> ().position.GetComponent<SquareBehaviour> ().host = false;
									rightRook.GetComponent<WhiteRookBehaviour> ().position.GetComponent<SquareBehaviour> ().guest = null;
									table.table [X].wOccupied [7] = false;
									rightRook.GetComponent<WhiteRookBehaviour> ().position = table.table [X].rows [Y + 1];
									rightRook.GetComponent<WhiteRookBehaviour> ().position.GetComponent<SquareBehaviour> ().guest = rightRook;
									rightRook.GetComponent<WhiteRookBehaviour> ().Y = Y + 1;
									rightRook.transform.position = new Vector3 (rightRook.GetComponent<WhiteRookBehaviour> ().position.transform.position.x, rightRook.GetComponent<WhiteRookBehaviour> ().position.transform.position.y, -1);
									table.table [X].wOccupied [Y + 1] = true;
								}
								if (j == Y - 2) {
									leftRook.GetComponent<WhiteRookBehaviour> ().position.GetComponent<SquareBehaviour> ().host = false;
									leftRook.GetComponent<WhiteRookBehaviour> ().position.GetComponent<SquareBehaviour> ().guest = null;
									table.table [X].wOccupied [0] = false;
									leftRook.GetComponent<WhiteRookBehaviour> ().position = table.table [X].rows [Y - 1];
									leftRook.GetComponent<WhiteRookBehaviour> ().position.GetComponent<SquareBehaviour> ().guest = leftRook;
									leftRook.GetComponent<WhiteRookBehaviour> ().Y = Y - 1;
									leftRook.transform.position = new Vector3 (leftRook.GetComponent<WhiteRookBehaviour> ().position.transform.position.x, leftRook.GetComponent<WhiteRookBehaviour> ().position.transform.position.y, -1);
									table.table [X].wOccupied [Y - 1] = true;
								}
							}
							leftCastling = false;
							rightCastling = false;
							table.table [i].rows [j].GetComponent<SquareBehaviour> ().moveHere = false;
							table.move = false;
							position.GetComponent<SquareBehaviour> ().selected = false;
							position.GetComponent<Animator> ().SetBool ("Selected", false);
							position.GetComponent<SquareBehaviour> ().host = false;
							position.GetComponent<SquareBehaviour> ().guest = null;
							table.table [X].wOccupied [Y] = false;
							position = table.table [i].rows [j];
							if (position.GetComponent<SquareBehaviour> ().guest) {
								DestroyImmediate (position.GetComponent<SquareBehaviour> ().guest);
								table.table [i].bOccupied [j] = false;
							}
							X = i;
							Y = j;
							position.GetComponent<SquareBehaviour> ().guest = this.gameObject;
							this.transform.position = new Vector3 (position.transform.position.x, position.transform.position.y, -1);
							table.table [i].wOccupied [j] = true;
							table.turn = !table.turn;
							if (table.bEnPassant) {
								table.bEnPassant = false;
								for (int k = 0; k < 8; k++){
									table.blackFront[k] = false;
								}
							}
							table.bTurnCheck = true;
							return;
						}
					}
				}
			} else {
				PossibleMoves ();
			}
		}
	}
}
