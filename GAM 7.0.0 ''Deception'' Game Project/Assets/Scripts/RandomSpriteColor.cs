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
	public Color MinColor;

	public Color MaxColor;

	private SpriteRenderer SPR;

	private void Start()
	{
		SPR = GetComponent<SpriteRenderer>();
		SPR.color = new Color(Random.Range(MinColor.r, MaxColor.r), Random.Range(MinColor.g, MaxColor.g), Random.Range(MinColor.b, MaxColor.b));
	}
}