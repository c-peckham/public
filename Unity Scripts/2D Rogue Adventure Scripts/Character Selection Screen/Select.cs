using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {

	public Sprite[] sprite;
	public SpriteRenderer spriterend;
	private int i=0;

	// Use this for initialization
	void Start () {
		spriterend= GetComponent<SpriteRenderer> ();
		spriterend.sprite = sprite [i];
		Instantiate(spriterend);
	}


	void Update ()
	{
		selection();
	}

	void selection()
	{
		if(Input.GetKey("left"))
		{
			i =- i;
			if (i < 0)
				i = sprite.Length;
		}
		else if(Input.GetKey("right"))
		{
			i =+ i;
			if (i > sprite.Length)
				i = 0;
		}
		spriterend.sprite = sprite [i];
	}
}
