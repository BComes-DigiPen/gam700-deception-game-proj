/*\
 *
 *	Filename:		GunnerController.cs
 *	Contributors:	BComes-DigiPen
 *	Date:			2021/01/28
 *	Description:	Script for the "Gunner" player / crosshair
 *	Assignment:		GAM 7.0.0: "Deception" Game Project/Jam
 *	Copyright:		(C) 2021 DigiPen (USA) Corporation. All rights reserved.
 *	Source License:	BSD 3-Clause License
 *
\*/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunnerController : MonoBehaviour
{
	public float ZPositionOverride = -5;
	public bool HideCursor = false;
	public bool LockCursor = false;
	public int RunnerLayer = 9;

	private SpriteRenderer SPR;
	private bool CollidingWithRunner = false;
	private bool CollidingWithRunnerPlayer = false;

	private void Start()
	{
		SPR = GetComponent<SpriteRenderer>();
		Cursor.visible = !HideCursor;
		Cursor.lockState = CursorLockMode.None;
		if (LockCursor)
			Cursor.lockState = CursorLockMode.Confined;
	}

	private void Update()
	{
		// Reset sprite color to white
		SPR.color = new Color(1, 1, 1);

		if (CollidingWithRunner)
			SPR.color = new Color(0, 1, 0);

		// Set sprite position to be where the mouse is on screen
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(transform.position.x, transform.position.y, ZPositionOverride);

		// Just to test if clicking works, set the sprite color to red when clicking. This will be changed to actually
		// do stuff later
		if (Input.GetMouseButton(0))
		{
			print("Click");
			SPR.color = new Color(1, 0, 0);
			if (CollidingWithRunner)
			{
				print("Hit a runner!");
				if (CollidingWithRunnerPlayer)
					print("Hit a running player!");
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D COL2D)
	{
		if (COL2D.gameObject.layer == RunnerLayer)
		{
			CollidingWithRunner = true;
			SPR.color = new Color(0, 1, 0);
			print("Started colliding with an object on layer " + RunnerLayer);
		}
		if (COL2D.gameObject.tag == "RunnerPlayer")
		{
			CollidingWithRunnerPlayer = true;
			print("RunnerPlayer");
		}
		if (COL2D.gameObject.tag == "RunnerNPC")
			print("RunnerNPC");
	}

	private void OnTriggerStay2D(Collider2D COL2D)
	{
		if (COL2D.gameObject.layer == RunnerLayer)
		{
			CollidingWithRunner = true;
			SPR.color = new Color(0, 1, 0);
			print("Still colliding with an object on layer " + RunnerLayer);
		}
		if (COL2D.gameObject.tag == "RunnerPlayer")
		{
			CollidingWithRunnerPlayer = true;
			print("RunnerPlayer");
		}
		if (COL2D.gameObject.tag == "RunnerNPC")
			print("RunnerNPC");
	}

	private void OnTriggerExit2D(Collider2D COL2D)
	{
		if (COL2D.gameObject.layer == RunnerLayer)
		{
			CollidingWithRunner = false;
			SPR.color = new Color(1, 1, 1);
			print("No longer colliding with an object on layer " + RunnerLayer);
		}
		if (COL2D.gameObject.tag == "RunnerPlayer")
		{
			CollidingWithRunnerPlayer = false;
			print("RunnerPlayer");
		}
		if (COL2D.gameObject.tag == "RunnerNPC")
			print("RunnerNPC");
	}
}