using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteTransformation : MonoBehaviour {

	public GameObject piece, newPiece;
	public string pieceName;
	public TableBehaviour table;

	// Use this for initialization
	void Start () {
		table = GameObject.Find ("Table").GetComponent<TableBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		int x = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().X;
		int y = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().Y;
		newPiece = GameObject.Instantiate (this.gameObject);
		newPiece.name = pieceName;
		newPiece.transform.SetParent (GameObject.Find ("WhitePieces").transform);
		newPiece.transform.position = new Vector3 (table.transformation.transform.position.x, table.transformation.transform.position.y, -1);
		newPiece.transform.localScale = new Vector3 (1, 1, 1);
		newPiece.GetComponent<BoxCollider2D> ().enabled = false;
		newPiece.GetComponent<WhiteTransformation> ().enabled = false;
		if (pieceName == "Knight") {
			newPiece.GetComponent<WhiteKnightBehaviour> ().enabled = true;
			newPiece.GetComponent<WhiteKnightBehaviour> ().position = table.transformation;
			newPiece.GetComponent<WhiteKnightBehaviour> ().X = x;
			newPiece.GetComponent<WhiteKnightBehaviour> ().Y = y;
			newPiece.GetComponent<WhiteKnightBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().compute;
			newPiece.GetComponent<WhiteKnightBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().king;
		}
		if (pieceName == "Bishop") {
			newPiece.GetComponent<WhiteBishopBehaviour> ().enabled = true;
			newPiece.GetComponent<WhiteBishopBehaviour> ().position = table.transformation;
			newPiece.GetComponent<WhiteBishopBehaviour> ().X = x;
			newPiece.GetComponent<WhiteBishopBehaviour> ().Y = y;
			newPiece.GetComponent<WhiteBishopBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().compute;
			newPiece.GetComponent<WhiteBishopBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().king;
		}
		if (pieceName == "Rook") {
			newPiece.GetComponent<WhiteRookBehaviour> ().enabled = true;
			newPiece.GetComponent<WhiteRookBehaviour> ().position = table.transformation;
			newPiece.GetComponent<WhiteRookBehaviour> ().X = x;
			newPiece.GetComponent<WhiteRookBehaviour> ().Y = y;
			newPiece.GetComponent<WhiteRookBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().compute;
			newPiece.GetComponent<WhiteRookBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().king;
		}
		if (pieceName == "Queen") {
			newPiece.GetComponent<WhiteQueenBehaviour> ().enabled = true;
			newPiece.GetComponent<WhiteQueenBehaviour> ().position = table.transformation;
			newPiece.GetComponent<WhiteQueenBehaviour> ().X = x;
			newPiece.GetComponent<WhiteQueenBehaviour> ().Y = y;
			newPiece.GetComponent<WhiteQueenBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().compute;
			newPiece.GetComponent<WhiteQueenBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<WhitePawnBehaviour> ().king;
		}
		DestroyImmediate (table.transformation.GetComponent<SquareBehaviour> ().guest);
		table.transformation.GetComponent<SquareBehaviour> ().guest = newPiece;
		table.transformation = null;
		this.transform.parent.gameObject.SetActive (false);
	}
}
