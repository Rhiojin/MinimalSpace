using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	public class PlanetStats
	{
		public float size = 0;
		public float gravity = 0;

	};

	public PlanetStats planetStats = new PlanetStats();

	void Start () 
	{
		BuildPlanet();
	}
	

	void BuildPlanet() 
	{
		float f_scale = Random.Range(9f,13f);
		Vector3 v_scale = new Vector3(f_scale,f_scale,f_scale);
		this.transform.localScale = v_scale;

		this.planetStats.size = f_scale;
		this.planetStats.gravity = Random.Range(f_scale, f_scale*2);
	}
}
