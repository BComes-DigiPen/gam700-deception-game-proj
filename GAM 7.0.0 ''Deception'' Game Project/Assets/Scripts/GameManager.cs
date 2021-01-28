using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//public GameState GameManagerState = GameState.InMainMenu;

	public enum GameState
	{ InMainMenu, InGame, Paused, GunnerVictory, RunnerVictory }; // add other states as needed

	// Start is called before the first frame update
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
	}
}