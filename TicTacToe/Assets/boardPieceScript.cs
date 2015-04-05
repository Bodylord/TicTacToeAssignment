using UnityEngine;
using System.Collections;

public class boardPieceScript : MonoBehaviour {

	public Sprite[] pieceTypes;
	public int ID;

	public int state; //-1 is unplayed, 0 is computer, 1 is player
	public bool isOccupied;
	public bool isPlayer;

	// Use this for initialization
	void Start () {
	
		name = "Piece " + ID;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
	
		if (GMscript.game.CurrentPlayer == 1) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = pieceTypes [1];
		}	
	}

	public void AImove(){
		if (GMscript.game.CurrentPlayer == 0) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = pieceTypes [2];
		}	
	}
}
