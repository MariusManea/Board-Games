using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPawnBehaviour : MonoBehaviour {

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

		if (!table.table [X - 1].wOccupied [Y] && !table.table [X - 1].bOccupied [Y]) {
			table.pTable = table.CopyTable(table.table);
			table.pTable [X].bOccupied [Y] = false;
			table.pTable [X - 1].bOccupied [Y] = true;
			compute.Compute (table.pTable);
			if (!table.pTable [king.GetComponent<BlackKingBehaviour> ().X].wAttacked [king.GetComponent<BlackKingBehaviour> ().Y]) {
				table.table [X - 1].rows [Y].GetComponent<SquareBehaviour> ().active = !table.bTurnCheck;
				table.bAble = true;
			}
			if (untouched) {
				if (!table.table [X - 2].wOccupied [Y] && !table.table [X - 2].bOccupied [Y]) {
					table.pTable = table.CopyTable(table.table);
					table.pTable [X].bOccupied [Y] = false;
					table.pTable [X - 2].bOccupied [Y] = true;
					compute.Compute (table.pTable);
					if (!table.pTable [king.GetComponent<BlackKingBehaviour> ().X].wAttacked [king.GetComponent<BlackKingBehaviour> ().Y]) {
						table.table [X - 2].rows [Y].GetComponent<SquareBehaviour> ().active = !table.bTurnCheck;
						table.bAble = true;
					}
				}
			}
		}
		if (Y < 7 && table.table [X - 1].wOccupied [Y + 1]) {
			table.pTable = table.CopyTable(table.table);
			table.pTable [X - 1].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
			table.pTable [X].bOccupied [Y] = false;
			table.pTable [X - 1].bOccupied [Y + 1] = true;
			compute.Compute (table.pTable);
			if (!table.pTable [king.GetComponent<BlackKingBehaviour> ().X].wAttacked [king.GetComponent<BlackKingBehaviour> ().Y]) {
				table.table [X - 1].rows [Y + 1].GetComponent<SquareBehaviour> ().active = !table.bTurnCheck;
				table.bAble = true;
			}
			table.pTable [X - 1].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
		}
		if (Y > 0 && table.table [X - 1].wOccupied [Y - 1]) {
			table.pTable = table.CopyTable(table.table);
			table.pTable [X - 1].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
			table.pTable [X].bOccupied [Y] = false;
			table.pTable [X - 1].bOccupied [Y - 1] = true;
			compute.Compute (table.pTable);
			if (!table.pTable [king.GetComponent<BlackKingBehaviour> ().X].wAttacked [king.GetComponent<BlackKingBehaviour> ().Y]) {
				table.table [X - 1].rows [Y - 1].GetComponent<SquareBehaviour> ().active = !table.bTurnCheck;
				table.bAble = true;
			}
			table.pTable [X - 1].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
		}
		if (X == 3 && table.wEnPassant) {
			if (Y < 7 && table.whiteFront [Y + 1]) {
				table.pTable = table.CopyTable(table.table);
				table.pTable [X].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
				table.pTable [X].bOccupied [Y] = false;
				table.pTable [X - 1].bOccupied [Y + 1] = true;
				compute.Compute (table.pTable);
				if (!table.pTable [king.GetComponent<BlackKingBehaviour> ().X].wAttacked [king.GetComponent<BlackKingBehaviour> ().Y]) {
					table.table [X - 1].rows [Y + 1].GetComponent<SquareBehaviour> ().active = !table.bTurnCheck;
					table.bAble = true;
				}
				table.pTable [X].rows [Y + 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
			}
			if (Y > 0 && table.whiteFront [Y - 1]) {
				table.pTable = table.CopyTable(table.table);
				table.pTable [X].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (false);
				table.pTable [X].bOccupied [Y] = false;
				table.pTable [X - 1].bOccupied [Y - 1] = true;
				compute.Compute (table.pTable);
				if (!table.pTable [king.GetComponent<BlackKingBehaviour> ().X].wAttacked [king.GetComponent<BlackKingBehaviour> ().Y]) {
					table.table [X - 1].rows [Y - 1].GetComponent<SquareBehaviour> ().active = !table.bTurnCheck;
					table.bAble = true;
				}
				table.pTable [X].rows [Y - 1].GetComponent<SquareBehaviour> ().guest.SetActive (true);
			}
		}
		if (table.bTurnCheck) {
			table.bToCheck++;
		}
	}
		

	// Update is called once per frame
	void Update () {
		if (position.GetComponent<SquareBehaviour> ().selected || table.bTurnCheck) {
			if (table.move) {
				for (int i = 0; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						if (table.table [i].rows [j].GetComponent<SquareBehaviour> ().moveHere) {
							if (untouched) {
								if (i == 4) {
									table.blackFront [j] = true;
									table.bEnPassant = true;
								}
							}
							table.table [i].rows [j].GetComponent<SquareBehaviour> ().moveHere = false;
							table.move = false;
							position.GetComponent<SquareBehaviour> ().selected = false;
							position.GetComponent<Animator> ().SetBool ("Selected", false);
							position.GetComponent<SquareBehaviour> ().host = false;
							position.GetComponent<SquareBehaviour> ().guest = null;
							table.table [X].bOccupied [Y] = false;
							position = table.table [i].rows [j];
							if (X == 3 && table.wEnPassant) {
								if (table.whiteFront [j]) {
									DestroyImmediate (table.table[X].rows[j].GetComponent<SquareBehaviour> ().guest);
									table.table [X].wOccupied [j] = false;
								}
							}
							if (position.GetComponent<SquareBehaviour> ().guest) {
								DestroyImmediate (position.GetComponent<SquareBehaviour> ().guest);
								table.table [i].wOccupied [j] = false;
							}
							X = i;
							Y = j;
							position.GetComponent<SquareBehaviour> ().guest = this.gameObject;
							table.turn = !table.turn;
							this.transform.position = new Vector3 (position.transform.position.x, position.transform.position.y, -1);
							untouched = false;
							if (table.wEnPassant) {
								table.wEnPassant = false;
								for (int k = 0; k < 8; k++){
									table.whiteFront[k] = false;
								}
							}
							table.table [i].bOccupied [j] = true;
							if (X == 0) {
								table.transformation = position;
								transformWindow.SetActive (true);
							}
							table.wTurnCheck = true;
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
