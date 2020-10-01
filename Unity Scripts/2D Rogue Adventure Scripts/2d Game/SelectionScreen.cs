using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionScreen : MonoBehaviour {

	public GameManager Startgame;
	public Button Left;
	public Button Right;
	public Button Begin;
	public Sprite [] player;


	void Start () {
		
		Startgame = GetComponent<GameManager> ();
		Button left = Left.GetComponent<Button> ();
		Button right = Right.GetComponent<Button> ();
		Button start = Begin.GetComponent<Button> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
