/*\
 *
 *	Filename:		RunnerShared.cs
 *	Contributors:	BComes-DigiPen
 *	Last Modified:	2021/01/29
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
	private bool Dead = false;
	private bool NPC = true;

	private void Start()
	{
		RB2D = GetComponent<Rigidbody2D>();
		RB2D.velocity = Vector2.zero;
		RB2D.gravityScale = 0;
		RB2D.angularVelocity = 0;
	}

	private void Update()
	{
		if (Dead)
		{
			MovementState = MovementStates.Dead;
			RB2D.velocity = Vector2.zero;
		}
	}

	public void KillRunner()
	{
		Dead = true;
		if (!NPC)
        {
			GameManager.SetState(GameState.GunnerVictory);
        }
	}

	public bool IsDead()
	{
		return Dead;
	}

	public bool IsNPC()
	{
		return NPC;
	}

	public void ToggleNPCState()
	{
		NPC = !NPC;
	}
}