using UnityEngine;
using System.Collections;

public class pcControl : MonoBehaviour {

	Vector3 currentPlanetPosition;
	Planet.PlanetStats currentPlantStats;

	bool hasPlanet = false;
	public Rigidbody2D rigidbody;
	public Transform transfrom;

	Vector3 zeroVector = Vector3.zero;

	float forwardThrust = 30;
	float angleThrust = -30;
	Vector2 thrustVector = Vector2.zero;
	Vector2 planetaryPull;

	void Start () 
	{
		thrustVector.x = forwardThrust;
		thrustVector.y = angleThrust;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput();
		Move();
		ApplyGravity();
		RotateToVelocity();
	}

	void GetInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			angleThrust *= -1;
			thrustVector.y = angleThrust;
		}

		if(Input.GetMouseButtonUp(0))
		{
			angleThrust *= -1;
			thrustVector.y = angleThrust;
		}
	}

	void Move()
	{
		this.rigidbody.AddForce(thrustVector);
	}

	void ApplyGravity()
	{
		if(hasPlanet)
		{
			this.planetaryPull = this.currentPlanetPosition - this.transform.position;
			this.rigidbody.AddForce(this.planetaryPull*this.currentPlantStats.gravity/5);
		}
	}

	void RotateToVelocity()
	{

		Vector2 v = GetComponent<Rigidbody2D>().velocity;
		float angle = Mathf.Atan2(this.rigidbody.velocity.y, this.rigidbody.velocity.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.CompareTag("planet"))
		{
			this.currentPlanetPosition = trigger.transform.position;
			this.currentPlantStats = trigger.transform.GetComponent<Planet>().planetStats;
			this.hasPlanet = true;
		}
	}

	void OnTriggerExit2D(Collider2D trigger)
	{
		hasPlanet = false;
		this.currentPlanetPosition = zeroVector;

	}

}
