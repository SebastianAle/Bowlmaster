using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour 
{
	void OnTriggerExit(Collider target)
	{
		GameObject pin = target.gameObject;

		if (pin.GetComponent<Pin> ()) 
		{
			Destroy (pin);
		}
	}
}
