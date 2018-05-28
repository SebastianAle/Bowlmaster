using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster
{
	// This returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative(List<int> rolls)
	{
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScores in ScoreFrames(rolls)) 
		{
			runningTotal += frameScores;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
		
	}

	//This returns a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames(List<int> rolls)
	{
		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) 
		{
			if (frames.Count == 10) 					//Prevents 11th frame score
			{
				break;
			}

			if (rolls [i - 1] + rolls [i] < 10) 		//Normal Open Frame
			{
				frames.Add (rolls [i - 1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) 					//Insuficient Look-Ahead
			{
				break;
			}

			if (rolls [i - 1] == 10) 					//STRIKE
			{
				i--;									//Strike frame has just one bowl
				frames.Add (10 + rolls [i + 1] + rolls[i + 2]);
			} 
			else if (rolls [i - 1] + rolls [i] == 10) 		//Calculate SPARE Bonus
			{
				frames.Add (10 + rolls [i + 1]);
			}
		}

		return frames;
	}
}
	