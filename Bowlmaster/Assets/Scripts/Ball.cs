using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public bool inPlay = false;
	public Vector3 ballVelocity;

	private Rigidbody myRigidbody;
	private AudioSource audioSource;
	private Vector3 ballStartPosition;
	private Quaternion ballStartRotation;


	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		myRigidbody.useGravity = false;

		ballStartPosition = this.transform.position;
		ballStartRotation = this.transform.rotation;
	}
	


	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		myRigidbody.useGravity = true;
		myRigidbody.velocity = velocity;
		audioSource.Play ();
	}

	public void Reset()
	{
		inPlay = false;
		transform.position = ballStartPosition;
		transform.rotation = ballStartRotation;
		myRigidbody.useGravity = false;
		myRigidbody.velocity = Vector3.zero;
		myRigidbody.angularVelocity = Vector3.zero;
	}
}
