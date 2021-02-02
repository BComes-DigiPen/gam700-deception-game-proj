/*\
 *
 *	Filename:		RunnerController.cs
 *	Contributors:	BComes-DigiPen
 *	Last Modified:	2021/01/29
 *	Description:	Script for the "Runner" player
 *	Assignment:		GAM 7.0.0: "Deception" Game Project/Jam
 *	Copyright:		(C) 2021 DigiPen (USA) Corporation. All rights reserved.
 *	Source License:	BSD 3-Clause License
 *
\*/

using UnityEngine;

public class RunnerController : MonoBehaviour
{
	public float SpeedMultiplier = 20;
	public float WalkSpeed = 20;
	public float RunSpeed = 40;

	private RunnerShared RS;

	Animator ani;

	private void Start()
	{
		RS = GetComponent<RunnerShared>();
		if (RS.IsNPC())
			RS.ToggleNPCState();

		ani = gameObject.GetComponent<Animator>();
	}

	private void Update()
	{
		if (!(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift)))
		{
			RS.RB2D.velocity = Vector2.zero;
			ani.SetBool("isMoving", false);
		}

		if (!RS.IsDead())
		{
			RS.MovementState = RunnerShared.MovementStates.Idle;

			if (Input.GetKey(KeyCode.Space))
			{
				RS.MovementState = RunnerShared.MovementStates.Walking;
				RS.RB2D.velocity = Vector2.right * WalkSpeed * SpeedMultiplier * Time.deltaTime;
				ani.SetBool("isMoving", true);
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				RS.MovementState = RunnerShared.MovementStates.Running;
				RS.RB2D.velocity = Vector2.right * RunSpeed * SpeedMultiplier * Time.deltaTime;
			}
		}
		else
		{
			print("The running player is dead!");
		}
	}
}