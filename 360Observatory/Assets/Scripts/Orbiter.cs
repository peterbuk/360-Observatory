/*
*	Modified from http://answers.unity3d.com/questions/463704/
*/

using UnityEngine;
using System.Collections;

public class Orbiter : MonoBehaviour {

	public Camera cam;
	public Vector3 axis = Vector3.up;
	public Vector3 target;
	public float radius = 15.0f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed = 80.0f;
	
	private Transform center;
	TrailRenderer trail;
	Material mat;
	
	// CONSTANTS
	private const float MIN_SIZE = -0.3f;
	private const float MAX_SIZE = 0.5f;
	
	void Start () {
		center = cam.transform;
		transform.position = (transform.position - center.position).normalized * radius + center.position;
		trail = gameObject.GetComponent<TrailRenderer>();
		mat = trail.material;
		
		Random.seed = System.DateTime.Now.Millisecond;
	}
	
	/*
	*	Used to add variety to orbit
	*/
	void RandomizeMovement() {
		radius = Random.Range (15, 30);
		axis = new Vector3(Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f));
		rotationSpeed = Random.Range (50, 300);

		float scaleFactor = Random.Range(MIN_SIZE, MAX_SIZE);
		
		transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
		renderer.material.color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));
	}
	
	void Update () {
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
		target = (transform.position - center.position).normalized * radius + center.position;
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * radiusSpeed);
		

	}
	
	
	//**************** Change events
	
	void ChangeSpeed (float value)
	{
		rotationSpeed = value;
	}	
	
	void ChangeSize (float value)
	{
		transform.localScale = new Vector3 (value, value, value);
		trail.startWidth = value;
	}
	
	void ChangeColour (Color color) 
	{
		renderer.material.color = color;
		mat.SetColor("_TintColor", color);
	}
}
