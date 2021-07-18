using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTableBehaviour : MonoBehaviour {

	[System.Serializable]
	public class MyArray{
		public GameObject[] point;
		public int[] checkers;
		public bool[] wOccupied;
		public bool[] bOccupied;
	}

	public MyArray table;
	public bool turn;
	//turn == false = white // turn == true = black
	public GameObject selectedPoint;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
