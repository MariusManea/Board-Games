using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForAttack : MonoBehaviour {

	public TableBehaviour Table;
	public Transform whitePieces, blackPieces;

	// Use this for initialization
	void Start () {
		Table = GameObject.Find ("Table").GetComponent<TableBehaviour> ();
	}

	void WhitePawn(int X, int Y, TableBehaviour.MyArray[] table){
		if (Y < 7 && X < 7) {
			table [X + 1].wAttacked [Y + 1] = true;
		}
		if (Y > 0 && X < 7) {
			table [X + 1].wAttacked [Y - 1] = true;
		}
	}
	void BlackPawn(int X, int Y, TableBehaviour.MyArray[] table){
		if (Y < 7 && X > 0) {
			table [X - 1].bAttacked [Y + 1] = true;
		}
		if (Y > 0 && X > 0) {
			table [X - 1].bAttacked [Y - 1] = true;
		}
	}

	void WhiteRook(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, -1, 0, 0 };
		int[] y = new int[] { 0, 0, 1, -1 };
		int p, q;
		for (int i = 0; i < 4; i++) {
			p = X;
			q = Y;
			bool more = true;
			while (more && p + x [i] >= 0 && p + x [i] < 8 && q + y [i] >= 0 && q + y [i] < 8) {
				if (table [p + x [i]].wOccupied [q + y [i]] || table [p + x [i]].bOccupied [q + y [i]]) {
					more = false;
				} 
				table [p + x [i]].wAttacked [q + y [i]] = true;
				p += x [i];
				q += y [i];
			}
		}
	}
	void BlackRook(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, -1, 0, 0 };
		int[] y = new int[] { 0, 0, 1, -1 };
		int p, q;
		for (int i = 0; i < 4; i++) {
			p = X;
			q = Y;
			bool more = true;
			while (more && p + x [i] >= 0 && p + x [i] < 8 && q + y [i] >= 0 && q + y [i] < 8) {
				if (table [p + x [i]].wOccupied [q + y [i]] || table [p + x [i]].bOccupied [q + y [i]]) {
					more = false;
				} 
				table [p + x [i]].bAttacked [q + y [i]] = true;
				p += x [i];
				q += y [i];
			}
		}
	}

	void WhiteKnight(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
		int[] y = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
		for (int i = 0; i < 8; i++) {
			if (X + x [i] >= 0 && X + x [i] <= 7 && Y + y [i] >= 0 && Y + y [i] <= 7) {
				table [X + x [i]].wAttacked [Y + y [i]] = true;
			}
		}
	}
	void BlackKnight(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
		int[] y = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
		for (int i = 0; i < 8; i++) {
			if (X + x [i] >= 0 && X + x [i] <= 7 && Y + y [i] >= 0 && Y + y [i] <= 7) {
				table [X + x [i]].bAttacked [Y + y [i]] = true;
			}
		}
	}

	void WhiteBishop(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, 1, -1, -1 };
		int[] y = new int[] { 1, -1, 1, -1 };
		int p, q;
		for (int i = 0; i < 4; i++) {
			p = X;
			q = Y;
			bool more = true;
			while (more && p + x [i] >= 0 && p + x [i] < 8 && q + y [i] >= 0 && q + y [i] < 8) {
				if (table [p + x [i]].wOccupied [q + y [i]] || table [p + x [i]].bOccupied [q + y [i]]) {
					more = false;
				} 
				table [p + x [i]].wAttacked [q + y [i]] = true;
				p += x [i];
				q += y [i];
			}
		}
	}
	void BlackBishop(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, 1, -1, -1 };
		int[] y = new int[] { 1, -1, 1, -1 };
		int p, q;
		for (int i = 0; i < 4; i++) {
			p = X;
			q = Y;
			bool more = true;
			while (more && p + x [i] >= 0 && p + x [i] < 8 && q + y [i] >= 0 && q + y [i] < 8) {
				if (table [p + x [i]].wOccupied [q + y [i]] || table [p + x [i]].bOccupied [q + y [i]]) {
					more = false;
				} 
				table [p + x [i]].bAttacked [q + y [i]] = true;
				p += x [i];
				q += y [i];
			}
		}
	}

	void WhiteQueen(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, 1, -1, -1, 1, -1, 0, 0 };
		int[] y = new int[] { 1, -1, 1, -1, 0, 0, 1, -1 };
		int p, q;
		for (int i = 0; i < 8; i++) {
			p = X;
			q = Y;
			bool more = true;
			while (more && p + x [i] >= 0 && p + x [i] < 8 && q + y [i] >= 0 && q + y [i] < 8) {
				if (table [p + x [i]].wOccupied [q + y [i]] || table [p + x [i]].bOccupied [q + y [i]]) {
					more = false;
				} 
				table [p + x [i]].wAttacked [q + y [i]] = true;
				p += x [i];
				q += y [i];
			}
		}
	}
	void BlackQueen(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, 1, -1, -1, 1, -1, 0, 0 };
		int[] y = new int[] { 1, -1, 1, -1, 0, 0, 1, -1 };
		int p, q;
		for (int i = 0; i < 8; i++) {
			p = X;
			q = Y;
			bool more = true;
			while (more && p + x [i] >= 0 && p + x [i] < 8 && q + y [i] >= 0 && q + y [i] < 8) {
				if (table [p + x [i]].wOccupied [q + y [i]] || table [p + x [i]].bOccupied [q + y [i]]) {
					more = false;
				} 
				table [p + x [i]].bAttacked [q + y [i]] = true;
				p += x [i];
				q += y [i];
			}
		}
	}

	void WhiteKing(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, 1, -1, -1, 1, -1, 0, 0 };
		int[] y = new int[] { 1, -1, 1, -1, 0, 0, 1, -1 };
		for (int i = 0; i < 8; i++) {
			if (X + x [i] >= 0 && X + x [i] <= 7 && Y + y [i] >= 0 && Y + y [i] <= 7) {
				table [X + x [i]].wAttacked [Y + y [i]] = true;
			}
		}
	}

	void BlackKing(int X, int Y, TableBehaviour.MyArray[] table){
		int[] x = new int[] { 1, 1, -1, -1, 1, -1, 0, 0 };
		int[] y = new int[] { 1, -1, 1, -1, 0, 0, 1, -1 };
		for (int i = 0; i < 8; i++) {
			if (X + x [i] >= 0 && X + x [i] <= 7 && Y + y [i] >= 0 && Y + y [i] <= 7) {
				table [X + x [i]].bAttacked [Y + y [i]] = true;
			}
		}
	}

	public void Compute(TableBehaviour.MyArray[] table){
		foreach (Transform piece in whitePieces) {
			if (piece.name == "Pawn" && piece.gameObject.activeSelf) {
				WhitePawn (piece.GetComponent<WhitePawnBehaviour>().X,piece.GetComponent<WhitePawnBehaviour>().Y,table);
			}
			if (piece.name == "Rook" && piece.gameObject.activeSelf) {
				WhiteRook (piece.GetComponent<WhiteRookBehaviour> ().X, piece.GetComponent<WhiteRookBehaviour> ().Y,table);
			}
			if (piece.name == "Knight" && piece.gameObject.activeSelf) {
				WhiteKnight (piece.GetComponent<WhiteKnightBehaviour> ().X, piece.GetComponent<WhiteKnightBehaviour> ().Y,table);
			}
			if (piece.name == "Bishop" && piece.gameObject.activeSelf) {
				WhiteBishop (piece.GetComponent<WhiteBishopBehaviour> ().X, piece.GetComponent<WhiteBishopBehaviour> ().Y,table);
			}
			if (piece.name == "Queen" && piece.gameObject.activeSelf) {
				WhiteQueen (piece.GetComponent<WhiteQueenBehaviour> ().X, piece.GetComponent<WhiteQueenBehaviour> ().Y,table);
			}
			if (piece.name == "King" && piece.gameObject.activeSelf) {
				WhiteKing (piece.GetComponent<WhiteKingBehaviour> ().X, piece.GetComponent<WhiteKingBehaviour> ().Y,table);
			}
		}
		foreach (Transform piece in blackPieces) {
			if (piece.name == "Pawn" && piece.gameObject.activeSelf) {
				BlackPawn (piece.GetComponent<BlackPawnBehaviour> ().X, piece.GetComponent<BlackPawnBehaviour> ().Y,table);
			}
			if (piece.name == "Rook" && piece.gameObject.activeSelf) {
				BlackRook (piece.GetComponent<BlackRookBehaviour> ().X, piece.GetComponent<BlackRookBehaviour> ().Y,table);
			}
			if (piece.name == "Knight" && piece.gameObject.activeSelf) {
				BlackKnight (piece.GetComponent<BlackKnightBehaviour> ().X, piece.GetComponent<BlackKnightBehaviour> ().Y,table);
			}
			if (piece.name == "Bishop" && piece.gameObject.activeSelf) {
				BlackBishop (piece.GetComponent<BlackBishopBehaviour> ().X, piece.GetComponent<BlackBishopBehaviour> ().Y,table);
			}
			if (piece.name == "Queen" && piece.gameObject.activeSelf) {
				BlackQueen (piece.GetComponent<BlackQueenBehaviour> ().X, piece.GetComponent<BlackQueenBehaviour> ().Y,table);
			}
			if (piece.name == "King" && piece.gameObject.activeSelf) {
				BlackKing (piece.GetComponent<BlackKingBehaviour> ().X, piece.GetComponent<BlackKingBehaviour> ().Y,table);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		Compute (Table.table);
	}
}
