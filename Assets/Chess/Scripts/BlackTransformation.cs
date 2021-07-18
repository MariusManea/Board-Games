using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackTransformation : MonoBehaviour {

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
		int x = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().X;
		int y = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().Y;
		newPiece = GameObject.Instantiate (this.gameObject);
		newPiece.name = pieceName;
		newPiece.transform.SetParent (GameObject.Find ("BlackPieces").transform);
		newPiece.transform.position = new Vector3 (table.transformation.transform.position.x, table.transformation.transform.position.y, -1);
		newPiece.transform.localScale = new Vector3 (1, 1, 1);
		newPiece.GetComponent<BoxCollider2D> ().enabled = false;
		newPiece.GetComponent<BlackTransformation> ().enabled = false;
		if (pieceName == "Knight") {
			newPiece.GetComponent<BlackKnightBehaviour> ().enabled = true;
			newPiece.GetComponent<BlackKnightBehaviour> ().position = table.transformation;
			newPiece.GetComponent<BlackKnightBehaviour> ().X = x;
			newPiece.GetComponent<BlackKnightBehaviour> ().Y = y;
			newPiece.GetComponent<BlackKnightBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().compute;
			newPiece.GetComponent<BlackKnightBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().king;
		}
		if (pieceName == "Bishop") {
			newPiece.GetComponent<BlackBishopBehaviour> ().enabled = true;
			newPiece.GetComponent<BlackBishopBehaviour> ().position = table.transformation;
			newPiece.GetComponent<BlackBishopBehaviour> ().X = x;
			newPiece.GetComponent<BlackBishopBehaviour> ().Y = y;
			newPiece.GetComponent<BlackBishopBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().compute;
			newPiece.GetComponent<BlackBishopBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().king;
		}
		if (pieceName == "Rook") {
			newPiece.GetComponent<BlackRookBehaviour> ().enabled = true;
			newPiece.GetComponent<BlackRookBehaviour> ().position = table.transformation;
			newPiece.GetComponent<BlackRookBehaviour> ().X = x;
			newPiece.GetComponent<BlackRookBehaviour> ().Y = y;
			newPiece.GetComponent<BlackRookBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().compute;
			newPiece.GetComponent<BlackRookBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().king;
		}
		if (pieceName == "Queen") {
			newPiece.GetComponent<BlackQueenBehaviour> ().enabled = true;
			newPiece.GetComponent<BlackQueenBehaviour> ().position = table.transformation;
			newPiece.GetComponent<BlackQueenBehaviour> ().X = x;
			newPiece.GetComponent<BlackQueenBehaviour> ().Y = y;
			newPiece.GetComponent<BlackQueenBehaviour> ().compute = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().compute;
			newPiece.GetComponent<BlackQueenBehaviour> ().king = table.transformation.GetComponent<SquareBehaviour> ().guest.GetComponent<BlackPawnBehaviour> ().king;
		}
		DestroyImmediate (table.transformation.GetComponent<SquareBehaviour> ().guest);
		table.transformation.GetComponent<SquareBehaviour> ().guest = newPiece;
		table.transformation = null;
		this.transform.parent.gameObject.SetActive (false);
	}
}
