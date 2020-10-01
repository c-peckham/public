using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {

	public Button mybutton;


	void Start () {

		Destroy (GameObject.Find ("SoundManager(Clone)"));
		Destroy (GameObject.Find ("Game Manager(Clone)"));

		Button Select = mybutton.GetComponent<Button> ();
		Select.onClick.AddListener (OnPress);

	}

	void OnPress()
	{
		SceneManager.LoadScene ("Main");
	}


}
