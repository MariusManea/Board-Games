using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehaviour : MonoBehaviour {
	[System.Serializable]
	public class MyArray {
		public GameObject[] rows;
		public bool[] wOccupied;
		public bool[] bOccupied;
		public bool[] wAttacked;
		public bool[] bAttacked;
	}

	public MyArray[] table,pTable;

	public GameObject selectedPiece, transformation, check, wKing, bKing, checkMate, draw, whitePieces, blackPieces;
	public bool[] whiteFront, blackFront; //for "en passant" rule
	public bool move, turn, wEnPassant, bEnPassant;
	public bool wAble, bAble, wTurnCheck, bTurnCheck;
	public int wToCheck, bToCheck;
	//turn == false = white // turn == true = black
	// Use this for initialization
	void Start () {
		wToCheck = 0;
		bToCheck = 0;
		wAble = true;
		bAble = true;
	}

	public MyArray[] CopyTable(MyArray[] table){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				pTable [i].rows [j] = table [i].rows [j];
				pTable [i].wOccupied [j] = table [i].wOccupied [j];
				pTable [i].bOccupied [j] = table [i].bOccupied [j];
				pTable [i].wAttacked [j] = false;
				pTable [i].bAttacked [j] = false;
			}
		}
		return pTable;
	}

	bool DrawCases(){
		if (whitePieces.transform.childCount <= 2 && blackPieces.transform.childCount <= 2) {
			if (whitePieces.transform.childCount == 1 && blackPieces.transform.childCount == 1) {
				return true;
			} else {
				bool wDraw = (whitePieces.transform.childCount == 1);
				bool bDraw = (blackPieces.transform.childCount == 1);
				foreach (Transform piece in whitePieces.transform) {
					if (piece.name != "Pawn" && piece.name != "Queen" && piece.name != "King" && piece.name != "Rook") {
						wDraw = true;
					}
				}
				foreach (Transform piece in blackPieces.transform) {
					if (piece.name != "Pawn" && piece.name != "Queen" && piece.name != "King" && piece.name != "Rook") {
						bDraw = true;
					}
				}
				if (wDraw && bDraw) {
					return true;
				}
			}
		}
		return false;
	}

	// Update is called once per frame
	void Update () {
		if (DrawCases ()) {
			draw.SetActive (true);
			foreach (Transform child in GameObject.Find("Margins").transform) {
				child.GetComponent<Animator> ().SetBool ("Check", false);
			}
			return;
		}
		if (wToCheck >= GameObject.Find ("WhitePieces").transform.childCount) {
			wTurnCheck = false;
			selectedPiece = null;
			wToCheck = 0;
		}
		if (bToCheck >= GameObject.Find ("BlackPieces").transform.childCount) {
			bTurnCheck = false;
			selectedPiece = null;
			bToCheck = 0;
		}
		if (!wAble && !turn && !wTurnCheck) {
			if (table [wKing.GetComponent<WhiteKingBehaviour> ().X].bAttacked [wKing.GetComponent<WhiteKingBehaviour> ().Y]) {
				check.SetActive (false);
				checkMate.SetActive (true);
			} else {
				draw.SetActive (true);
			}
		}
		if (!bAble && turn && !bTurnCheck) {
			if (table [bKing.GetComponent<BlackKingBehaviour> ().X].wAttacked [bKing.GetComponent<BlackKingBehaviour> ().Y]) {
				check.SetActive (false);
				checkMate.SetActive (true);
			} else {
				draw.SetActive (true);
			}
		}
		if (turn) {
			wAble = false;
		}
		if (!turn) {
			bAble = false;
		}
		if (wKing.GetComponent<WhiteKingBehaviour> ().check || bKing.GetComponent<BlackKingBehaviour> ().check) {
			check.SetActive (true);
			foreach (Transform child in GameObject.Find("Margins").transform) {
				child.GetComponent<Animator> ().SetBool ("Check", true);
			}
		} else {
			check.SetActive (false);
			foreach (Transform child in GameObject.Find("Margins").transform) {
				child.GetComponent<Animator> ().SetBool ("Check", false);
			}
		}
	}
}
