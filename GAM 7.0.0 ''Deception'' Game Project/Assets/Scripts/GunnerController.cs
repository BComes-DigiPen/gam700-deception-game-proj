/*\
 *
 *	Filename:		GunnerController.cs
 *	Contributors:	BComes-DigiPen
 *	Date:			2021/01/27
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

	private CircleCollider2D CC2D;
	private SpriteRenderer SPR;

	private void Start()
	{
		CC2D = GetComponent<CircleCollider2D>();
		SPR = GetComponent<SpriteRenderer>();
		Cursor.visible = !HideCursor;
		Cursor.lockState = CursorLockMode.None;
		if (LockCursor)
			Cursor.lockState = CursorLockMode.Confined;
	}

	private void Update()
	{
		// Reset sprite color to white
		SPR.color = new Color(255, 255, 255);

		// Set sprite position to be where the mouse is on screen
		transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, ZPositionOverride);

		// Just to test if clicking works, set the sprite color to red when clicking. This will be changed to actually
		// do stuff later
		if (Input.GetMouseButton(0))
		{
			print("GunnerController.Update() says \"Click\"");
			SPR.color = new Color(255, 0, 0);
		}
	}
}