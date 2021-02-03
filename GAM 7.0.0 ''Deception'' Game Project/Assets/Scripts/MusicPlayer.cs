/*\
 *
 *	Filename:		MusicPlayer.cs
 *	Contributors:	Acoliversa, BComes-DigiPen
 *	Last Modified:	2021/02/02
 *	Description:	Script which automatically plays sound from the parent object's AudioSource component
 *	Assignment:		GAM 7.0.0: "Deception" Game Project/Jam
 *	Copyright:		(C) 2021 DigiPen (USA) Corporation. All rights reserved.
 *	Source License:	BSD 3-Clause License
 *
\*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private AudioSource audSrc;

	private void Start()
	{
		audSrc = GetComponent<AudioSource>();
		audSrc.Play();
	}

	private void Update()
	{
		if (GameManager.state != GameState.InGame)
			audSrc.Stop();
	}
}