﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float SpawnWait;
	public float startWait;
	public float waveWait;


	public Text restartText;
	public Text GameOverText;
	public Text scoreText;


	private bool gameOver;
	private bool restart;
	private int score;

	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		GameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}

	void Update()
	{
		if(restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}

		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(SpawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

	}
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;

	}

	public void GameOver()
	{
		GameOverText.text = "Game Over!";
		gameOver = true;
	}

}
