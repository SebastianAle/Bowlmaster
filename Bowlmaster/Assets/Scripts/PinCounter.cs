using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour 
{
	public Text standingDisplay;

	private GameManager gameManager;
	private bool ballOutOfPlay = false;
	private float lastChangeTime;
	private int lastStandingCount = -1;
	private int lastSettleCount = 10;

	// Use this for initialization
	void Start () 
	{
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) 
		{
			CheckStanding ();
			standingDisplay.color = Color.red;
		}
	}

	public void Reset()
	{
		lastSettleCount = 10;
	}

	void OnTriggerExit(Collider target)
	{
		if (target.gameObject.name == "Ball") 
		{
			ballOutOfPlay = true;
		}

	}

	void CheckStanding()
	{
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) 
		{
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;
		if((Time.time - lastChangeTime) > settleTime)
		{
			PinsHaveSettled ();
		}
	}

	void PinsHaveSettled()
	{
		int standing = CountStanding ();
		int pinFall = lastSettleCount - standing;
		lastSettleCount = standing;

		gameManager.Bowl (pinFall);

		lastStandingCount = -1; //Indicates a new frame
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding ()
	{
		int pinsStanding = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) 
		{
			if (pin.IsStanding()) 
			{
				pinsStanding++;
			}
		}

		return pinsStanding;
	}
}
