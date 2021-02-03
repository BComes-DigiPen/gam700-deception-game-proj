/*\
 *
 *	Filename:		RunnerShared.cs
 *	Contributors:	BComes-DigiPen
 *	Last Modified:	2021/02/02
 *	Description:	Script containing shared variables & logic for the "Runner" players and NPCs
 *	Assignment:		GAM 7.0.0: "Deception" Game Project/Jam
 *	Copyright:		(C) 2021 DigiPen (USA) Corporation. All rights reserved.
 *	Source License:	BSD 3-Clause License
 *
\*/

using UnityEngine;

public class RunnerShared : MonoBehaviour
{
	public enum MovementStates { Idle, Dead, Walking, Running };

	public MovementStates MovementState = MovementStates.Idle;
	public Rigidbody2D RB2D;

	private bool Dead;
	private bool NPC = true;

	private Transform FinishLineTransform;
	private float FinishLineXPosition;

	private void Start()
	{
		RB2D = GetComponent<Rigidbody2D>();
		RB2D.velocity = Vector2.zero;
		RB2D.gravityScale = 0;
		RB2D.angularVelocity = 0;

		FinishLineTransform = GameObject.Find("FinishLine").transform;
		FinishLineXPosition = FinishLineTransform.position.x;
	}

	private void Update()
	{
		if (transform.position.x >= FinishLineXPosition)
		{
			KillRunner(); // "kill" the runner to stop movement once at the finish line

			if (!NPC)
				GameManager.SetState(GameState.RunnerVictory); // end the game if we are a player
		}

		if (Dead)
		{
			MovementState = MovementStates.Dead;
			RB2D.velocity = Vector2.zero;

			if (!NPC)
				GameManager.SetState(GameState.GunnerVictory);
		}
	}

	public void KillRunner() => Dead = true;

	public bool IsDead() => Dead;

	public bool IsNPC() => NPC;

	public void ToggleNPCState() => NPC = !NPC;
}