﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	private List<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () 
	{
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();
	}
	
	public void Bowl(int pinFall)
	{
		try {
			bowls.Add (pinFall);
			ball.Reset ();
			pinSetter.PerformAction (ActionMaster.NextAction (bowls));
		} catch 
		{
			Debug.LogWarning ("Something went wrong in Bowl()");
		}


		scoreDisplay.FillRollCard (bowls);
	}
}
