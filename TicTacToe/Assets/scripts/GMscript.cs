using UnityEngine;
using System.Collections;

public class GMscript : MonoBehaviour {

	public GameObject[] pieceList;


	public Vector3[] pieceSpots;
	public GameObject boardPiece;

	public int CurrentPlayer;
	public static GMscript game;

	int[][] wins = new int[][] {
		new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 },
		new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 },
		new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 } };

	public int[] GameBoard = new int[9];
	public int Unplayed = -1;
	public const int Computer = 0;
	public const int Human = 1;

//	public string[][] Players = new string[][] {
//		new string[] { "COMPUTER", "X" }, // computer player
//		new string[] { "HUMAN", "O" } // human player
//	};

	void Awake(){
	
		game = this;

		initializeGameBoard ();
//		displayGameBoard ();

	}
	// Use this for initialization
	void Start () {
	
		CurrentPlayer = 1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//creates the board
	void initializeGameBoard()
	{
		for (int i = 0; i < GameBoard.Length; i++) {
			GameBoard [i] = Unplayed;
			GameObject GB = Instantiate (boardPiece, pieceSpots [i], transform.rotation) as GameObject;
			pieceList[i] = GB;
			GB.GetComponent<boardPieceScript> ().ID = i;
		}
	}

//	//prints bullshit to the console
//	void displayGameBoard()
//	{
//		print(string.Format (" {0} | {1} | {2}", pieceAt(0), pieceAt(1), pieceAt(2)));
//		print("---|---|---");
//		print (string.Format (" {0} | {1} | {2}", pieceAt(3), pieceAt(4), pieceAt(5)));
//		print("---|---|---");
//		print (string.Format (" {0} | {1} | {2}", pieceAt(6), pieceAt(7), pieceAt(8)));
//	}
//
//	//player name (computer, player)
//	string playerName(int player)
//	{
//		return Players[player][0];
//	}
//
//	//playerToken (x, o)
//	string playerToken(int player)
//	{
//		return Players[player][1];
//	}
//
	//looks for the next player
	public int getNextPlayer(int player)
	{
		return (player + 1) % 2;
	}
//
//	//checks where each thing is at on the board
//	string pieceAt(int boardPosition)
//	{
//		if (GameBoard[boardPosition] == Unplayed)
//		{
//			return (boardPosition + 1).ToString();
//		// display 1..9 on board rather than 0..8
//		}
//		return "";
//	}

	//checks if a player matched 
	public bool isGameWon()
	{
		for (int i = 0; i < wins.Length; i++) {
			return takenBySamePlayer(wins[i][0], wins[i][1], wins[i][2]);
		}

		return false;
	}

	public bool takenBySamePlayer(int a, int b, int c)
	{
		return GameBoard[a] != Unplayed && GameBoard[a] ==
			GameBoard[b] && GameBoard[a] == GameBoard[c];
	}

	public bool isGameTied()
	{
		//what should go here?
		return false;
	}

	void playMove(int boardPosition, int player)
	{
		GameBoard[boardPosition] = player;
	}

	public int getRandomMove () {
		int i = 0;
		int movesLeft = 0;
		//find the number of unplayed positions
		for (i = 0; i < GameBoard.Length; i++) {
			if(GameBoard[i]==Unplayed)
			{
				movesLeft = movesLeft + 1;
			}
		}
		int x = Random.Range(0, movesLeft);
		for (i = 0; i < GameBoard.Length; i++) // walk board ...
		{
			if (GameBoard[i] == Unplayed && x == 0) 
				return i;
			x--;
		}
		return i;
	}

	int getManualMove(int player){

		return Unplayed;
		//what should go here?
	}
}
