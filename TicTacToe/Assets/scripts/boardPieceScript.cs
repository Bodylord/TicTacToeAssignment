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

		if(GMscript.game.CurrentPlayer == 0){
			AImove();
		}
	
	}

	void OnMouseDown(){
		if (GMscript.game.CurrentPlayer == 1 && GMscript.game.GameBoard[ID] == -1) {

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = pieceTypes [1];
			GMscript.game.GameBoard[ID] = 1;

		if(GMscript.game.isGameWon() == true){

				print ("p1 WINAR");
				GMscript.game.CurrentPlayer = 3;
			}

			else GMscript.game.CurrentPlayer = GMscript.game.getNextPlayer(GMscript.game.CurrentPlayer);
					
		}

//		else AImove();
	}

	public void AImove(){

		if (ID == GMscript.game.getRandomMove())
		{
		GMscript.game.GameBoard[ID] = 0;
			GetComponent<SpriteRenderer> ().sprite = pieceTypes [2];

		if(GMscript.game.isGameWon() == true){
			print ("p2 WINAR");
		}
		
		else GMscript.game.CurrentPlayer = GMscript.game.getNextPlayer(GMscript.game.CurrentPlayer);
		}
	}

}
