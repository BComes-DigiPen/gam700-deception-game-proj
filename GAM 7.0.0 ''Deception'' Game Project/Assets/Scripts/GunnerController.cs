/*\
 *
 *	Filename:		GunnerController.cs
 *	Contributors:	BComes-DigiPen
 *	Last Modified:	2021/02/01
 *	Description:	Script for the "Gunner" player / crosshair
 *	Assignment:		GAM 7.0.0: "Deception" Game Project/Jam
 *	Copyright:		(C) 2021 DigiPen (USA) Corporation. All rights reserved.
 *	Source License:	BSD 3-Clause License
 *
\*/

using UnityEngine;

public class GunnerController : MonoBehaviour
{
	public float ZPosOverride = -5;
	public bool HideCursor = false;
	public bool LockCursor = false;

	private LayerMask RunnerLayer;
	private SpriteRenderer SPR;
	private bool OverlappingRunner = false;
	private GameObject LastCollidedObject = null;

	private void Start()
	{
		SPR = GetComponent<SpriteRenderer>();
		RunnerLayer = LayerMask.NameToLayer("RunnerLayer");

		Cursor.visible = !HideCursor;
		Cursor.lockState = CursorLockMode.None;
		if (LockCursor)
			Cursor.lockState = CursorLockMode.Confined;
	}

	private void Update()
	{
		// Reset sprite color to white
		SPR.color = Color.white;
		transform.rotation = new Quaternion(0, 0, 0, 0);

		if (OverlappingRunner && !LastCollidedObject.GetComponent<RunnerShared>().IsDead())
		{
			transform.Rotate(0, 0, 45);
			SPR.color = Color.green;
		}

		// Set sprite position to cursor, make sure Z position is over other objects so it is visible at all times
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(transform.position.x, transform.position.y, ZPosOverride);

		if (Input.GetMouseButton(0))
		{
			SPR.color = Color.red;
			if (OverlappingRunner)
				LastCollidedObject.GetComponent<RunnerShared>().KillRunner();
			// forget the last object we overlapped, since we didn't shoot it
			LastCollidedObject = null;
			OverlappingRunner = false;
		}
	}

	private void OnTriggerStay2D(Collider2D COL2D)
	{
		LastCollidedObject = COL2D.gameObject;
		if (LastCollidedObject.layer == RunnerLayer)
		{
			OverlappingRunner = true;
			SPR.color = Color.green;
		}
	}

	private void OnTriggerExit2D(Collider2D COL2D)
	{
		LastCollidedObject = null;
		OverlappingRunner = false;
		SPR.color = Color.white;
	}
}