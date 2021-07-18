using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {

	public TableBehaviour table;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				table.table [i].bAttacked [j] = false;
				table.table [i].wAttacked [j] = false;
				table.table [i].bOccupied [j] = false;
				table.table [i].wOccupied [j] = false;
			}
		}
		foreach(Transform square in GameObject.Find("WhiteSquares").transform){
			if (square.GetComponent<SquareBehaviour> ().guest) {
				table.table [(int)(square.name [1] - '1')].wOccupied [(int)(square.name [0] - 'A')] = (square.GetComponent<SquareBehaviour> ().guest.transform.parent.name == "WhitePieces");
				table.table [(int)(square.name [1] - '1')].bOccupied [(int)(square.name [0] - 'A')] = (square.GetComponent<SquareBehaviour> ().guest.transform.parent.name == "BlackPieces");
			}
		}
		foreach(Transform square in GameObject.Find("BlackSquares").transform){
			if (square.GetComponent<SquareBehaviour> ().guest) {
				table.table [(int)(square.name [1] - '1')].wOccupied [(int)(square.name [0] - 'A')] = (square.GetComponent<SquareBehaviour> ().guest.transform.parent.name == "WhitePieces");
				table.table [(int)(square.name [1] - '1')].bOccupied [(int)(square.name [0] - 'A')] = (square.GetComponent<SquareBehaviour> ().guest.transform.parent.name == "BlackPieces");
			}
		}
	}
}
