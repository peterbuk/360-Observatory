using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private float SPAWN_RATE = 1.0f;	// how often to spawn an object
	private float timer;
	
	public GameObject sphere;

	// Use this for initialization
	void Start () {
		timer = SPAWN_RATE;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		
		if (timer < 0)
		{
			timer = SPAWN_RATE;
			
			GameObject obj = (GameObject) Instantiate (sphere, sphere.transform.position, Quaternion.identity);
			obj.SendMessage("RandomizeMovement");
		}
	}
}
