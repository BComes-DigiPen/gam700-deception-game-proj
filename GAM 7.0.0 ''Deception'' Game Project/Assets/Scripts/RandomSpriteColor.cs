/*\
 *
 *	Filename:		GunnerController.cs
 *	Contributors:	BComes-DigiPen
 *	Date:			2021/01/28
 *	Description:	Literally just sets a random sprite color on Start(). That's it.
 *	Assignment:		GAM 7.0.0: "Deception" Game Project/Jam
 *	Copyright:		(C) 2021 DigiPen (USA) Corporation. All rights reserved.
 *	Source License:	BSD 3-Clause License
 *
\*/

using UnityEngine;

public class RandomSpriteColor : MonoBehaviour
{
	[Range(0, 1)]
	public float RMin = .5f;

	[Range(0, 1)]
	public float RMax = .75f;

	[Range(0, 1)]
	public float GMin = .5f;

	[Range(0, 1)]
	public float GMax = .75f;

	[Range(0, 1)]
	public float BMin = .5f;

	[Range(0, 1)]
	public float BMax = .75f;

	private SpriteRenderer SPR;

	private void Start()
	{
		SPR = GetComponent<SpriteRenderer>();
		SPR.color = new Color(Random.Range(RMin, RMax), Random.Range(GMin, GMax), Random.Range(BMin, BMax));
	}
}