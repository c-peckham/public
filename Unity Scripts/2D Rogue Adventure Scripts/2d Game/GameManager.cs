using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour{

	public float levelStartDelay = 2f;
	public float gameEndDelay = 2f;
	public float turnDelay = 0.1f;
	public int playerFoodPoints = 100;
	public static GameManager instance = null;
	public Button replay;
	[HideInInspector]public bool playersTurn = true;

	public BoardManager boardScript;

	private Text levelText;
	private GameObject levelImage;
	private int level = 0;
	private List<Enemy> enemies;
	private bool enemiesMoving;
	private bool doingSetup;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Button restart = replay.GetComponent<Button> ();

		restart.gameObject.SetActive (false);

		DontDestroyOnLoad (gameObject);
		enemies = new List<Enemy> ();
		boardScript = GetComponent<BoardManager> ();
	
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		level++;
		InitGame ();
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void InitGame ()
	{
		doingSetup = true;
		levelImage = GameObject.Find ("Level Image");
		levelText = GameObject.Find ("Level Text").GetComponent<Text> ();
		levelText.text = "Day " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
		enemies.Clear ();
		boardScript.SetupScene(level);
	
	}

	private void HideLevelImage()
	{
		levelImage.SetActive(false);
		doingSetup = false;
	}

	void Update()
	{
		if (playersTurn || enemiesMoving || doingSetup)
			return;
		StartCoroutine (MoveEnemies ());
	}

	public void AddEnemyToList(Enemy script)
	{
		enemies.Add (script);
	}

	public void GameOver()
	{
		levelText.text = "After " + level + " days, you starved";
		levelImage.SetActive (true);
		enabled = false;
		Button restart = replay.GetComponent<Button> ();
		restart.onClick.AddListener (Restart);
		restart.gameObject.SetActive (true);
	}

	public void Restart()
	{
		SceneManager.LoadScene ("Title", LoadSceneMode.Single);
	}

	IEnumerator MoveEnemies()
	{
		enemiesMoving = true;
		yield return new WaitForSeconds (turnDelay);
		if (enemies.Count == 0) {
			yield return new WaitForSeconds (turnDelay);
		}
		for (int i = 0; i < enemies.Count; i++) {
			enemies [i].MoveEnemy ();
			yield return new WaitForSeconds (enemies [i].moveTime);
		}

		playersTurn = true;
		enemiesMoving = false;

	}
}
