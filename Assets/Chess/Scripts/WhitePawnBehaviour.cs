using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawnBehaviour : MonoBehaviour {

	public GameObject position, transformWindow, king;
	public bool untouched, selected;
	public int X, Y;
	public TableBehaviour table;
	public CheckForAttack compute;

	// Use this for initialization
	void Start () {
		untouched = true;
		selected = false;
		table = GameObject.Find ("Table").GetComponent<TableBehaviour> ();

	}

	void PossibleMoves (){
		if (!table.table [X + 1].wOccupied [Y] && !table.table [X + 1].bOccupied [Y]) {
			table.pTable = table.CopyTable(table.table);
			table.pTable [X].wOccupied [Y] = false;
			table.pTable [X + 1].wOccupied [Y] = true;
			compute.Compute (table.pTable);
			if (!table.pTable [king.GetComponent<WhiteKingBehaviour> ().X].bAttacked [king.GetComponent<WhiteKingBehaviour> ().Y]) {
				table.table [X + 1].rows [Y].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
				table.wAble = true;
			}
			if (untouched) {
				if (!table.table [X + 2].wOccupied [Y] && !table.table [X + 2].bOccupied [Y]) {
					table.pTable = table.CopyTable(table.table);
					table.pTable [X].wOccupied [Y] = false;
					table.pTable [X + 2].wOccupied [Y] = true;
					compute.Compute (table.pTable);
					if (!table.pTable [king.GetComponent<WhiteKingBehaviour> ().X].bAttacked [king.GetComponent<WhiteKingBehaviour> ().Y]) {
						table.table [X + 2].rows [Y].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
						table.wAble = true;
					}
				}
			}
		}
		if (Y < 7 && table.table [X + 1].bOccupied [Y + 1]) {
			table.pTable = table.CopyTable(table.table);
			table.pTable [X + 1].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
			table.pTable [X].wOccupied [Y] = false;
			table.pTable [X + 1].wOccupied [Y + 1] = true;
			compute.Compute (table.pTable);
			if (!table.pTable [king.GetComponent<WhiteKingBehaviour> ().X].bAttacked [king.GetComponent<WhiteKingBehaviour> ().Y]) {
				table.table [X + 1].rows [Y + 1].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
				table.wAble = true;
			}
			table.pTable [X + 1].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
		}
		if (Y > 0 && table.table [X + 1].bOccupied [Y - 1]) {
			table.pTable = table.CopyTable(table.table);
			table.pTable [X + 1].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
			table.pTable [X].wOccupied [Y] = false;
			table.pTable [X + 1].wOccupied [Y - 1] = true;
			compute.Compute (table.pTable);
			if (!table.pTable [king.GetComponent<WhiteKingBehaviour> ().X].bAttacked [king.GetComponent<WhiteKingBehaviour> ().Y]) {
				table.table [X + 1].rows [Y - 1].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
				table.wAble = true;
			}
			table.pTable [X + 1].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
		}
		if (X == 4 && table.bEnPassant) {
			if (Y < 7 && table.blackFront [Y + 1]) {
				table.pTable = table.CopyTable(table.table);
				table.pTable [X].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
				table.pTable [X].wOccupied [Y] = false;
				table.pTable [X + 1].wOccupied [Y + 1] = true;
				compute.Compute (table.pTable);
				if (!table.pTable [king.GetComponent<WhiteKingBehaviour> ().X].bAttacked [king.GetComponent<WhiteKingBehaviour> ().Y]) {
					table.table [X + 1].rows [Y + 1].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
					table.wAble = true;
				}
				table.pTable [X].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
			}
			if (Y > 0 && table.blackFront [Y - 1]) {
				table.pTable = table.CopyTable(table.table);
				table.pTable [X].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
				table.pTable [X].wOccupied [Y] = false;
				table.pTable [X + 1].wOccupied [Y - 1] = true;
				compute.Compute (table.pTable);
				if (!table.pTable [king.GetComponent<WhiteKingBehaviour> ().X].bAttacked [king.GetComponent<WhiteKingBehaviour> ().Y]) {
					table.table [X + 1].rows [Y - 1].GetComponent<SquareBehaviour> ().active = !table.wTurnCheck;
					table.wAble = true;
				}
				table.pTable [X].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
			}
		}
		if (table.wTurnCheck) {
			table.wToCheck++;
		}
	}
		

	// Update is called once per frame
	void Update () {
		if (position.GetComponent<SquareBehaviour> ().selected || table.wTurnCheck) {
			if (table.move) {
				for (int i = 0; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						if (table.table [i].rows [j].GetComponent<SquareBehaviour> ().moveHere) {
							if (untouched) {
								if (i == 3) {
									table.whiteFront [j] = true;
									table.wEnPassant = true;
								}
							}
							table.table [i].rows [j].GetComponent<SquareBehaviour> ().moveHere = false;
							table.move = false;
							position.GetComponent<SquareBehaviour> ().selected = false;
							position.GetComponent<Animator> ().SetBool ("Selected", false);
							position.GetComponent<SquareBehaviour> ().host = false;
							position.GetComponent<SquareBehaviour> ().guest = null;
							table.table [X].wOccupied [Y] = false;
							position = table.table [i].rows [j];
							if (X == 4 && table.bEnPassant) {
								if (table.blackFront [j]) {
									DestroyImmediate (table.table[X].rows[j].GetComponent<SquareBehaviour> ().guest);
									table.table [X].bOccupied [j] = false;
								}
							}
							if (position.GetComponent<SquareBehaviour> ().guest) {
								DestroyImmediate (position.GetComponent<SquareBehaviour> ().guest);
								table.table [i].bOccupied [j] = false;
							}
							X = i;
							Y = j;
							position.GetComponent<SquareBehaviour> ().guest = this.gameObject;
							this.transform.position = new Vector3 (position.transform.position.x, position.transform.position.y, -1);
							table.turn = !table.turn;
							untouched = false;
							if (table.bEnPassant) {
								table.bEnPassant = false;
								for (int k = 0; k < 8; k++){
									table.blackFront[k] = false;
								}
							}
							table.table [i].wOccupied [j] = true;
							if (X == 7) {
								table.transformation = position;
								transformWindow.SetActive (true);
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
