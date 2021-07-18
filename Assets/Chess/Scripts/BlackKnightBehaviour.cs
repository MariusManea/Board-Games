using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnightBehaviour : MonoBehaviour {

	public GameObject position, transformWindow, king;
	public bool selected;
	public int X, Y;
	public TableBehaviour table;
	public CheckForAttack compute;

	// Use this for initialization
	void Start () {
		selected = false;
		table = GameObject.Find ("Table").GetComponent<TableBehaviour> ();

	}

	void PossibleMoves (){
		int[] x = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
		int[] y = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
		for (int i = 0; i < 8; i++) {
			if (X + x [i] >= 0 && X + x [i] <= 7 && Y + y [i] >= 0 && Y + y [i] <= 7 && !table.table [X + x [i]].bOccupied [Y + y [i]]) {
				table.pTable = table.CopyTable(table.table);
				if (table.pTable [X + x [i]].wOccupied [Y + y [i]]) {
					table.pTable [X + x [i]].rows [Y + y [i]].GetComponent<SquareBehaviour> ().guest.SetActive (false);
				}
				table.pTable [X].bOccupied [Y] = false;
				table.pTable [X + x [i]].bOccupied [Y + y [i]] = true;
				compute.Compute (table.pTable);
				if (!table.pTable [king.GetComponent<BlackKingBehaviour> ().X].wAttacked [king.GetComponent<BlackKingBehaviour> ().Y]) {
					table.table [X + x [i]].rows [Y + y [i]].GetComponent<SquareBehaviour> ().active = !table.bTurnCheck;
					table.bAble = true;
				}
				if (table.pTable [X + x [i]].wOccupied [Y + y [i]]) {
					table.pTable [X + x [i]].rows [Y + y [i]].GetComponent<SquareBehaviour> ().guest.SetActive (true);
				}
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
							table.table [i].rows [j].GetComponent<SquareBehaviour> ().moveHere = false;
							table.move = false;
							position.GetComponent<SquareBehaviour> ().selected = false;
							position.GetComponent<Animator> ().SetBool ("Selected", false);
							position.GetComponent<SquareBehaviour> ().host = false;
							position.GetComponent<SquareBehaviour> ().guest = null;
							table.table [X].bOccupied [Y] = false;
							position = table.table [i].rows [j];
							if (position.GetComponent<SquareBehaviour> ().guest) {
								DestroyImmediate (position.GetComponent<SquareBehaviour> ().guest);
								table.table [i].wOccupied [j] = false;
							}
							X = i;
							Y = j;
							position.GetComponent<SquareBehaviour> ().guest = this.gameObject;
							this.transform.position = new Vector3 (position.transform.position.x, position.transform.position.y, -1);
							table.table [i].bOccupied [j] = true;
							table.turn = !table.turn;
							if (table.wEnPassant) {
								table.wEnPassant = false;
								for (int k = 0; k < 8; k++){
									table.whiteFront[k] = false;
								}
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
