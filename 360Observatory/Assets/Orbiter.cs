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
	
	// CONSTANTS
	private const float MIN_SIZE = -2f;
	private const float MAX_SIZE = 2f;
	
	void Start () {
		center = cam.transform;
		transform.position = (transform.position - center.position).normalized * radius + center.position;
	}
	
	/*
	*	Used to add variety to orbit
	*/
	void RandomizeMovement() {
		radius = Random.Range (5, 30);
		axis = new Vector3(Random.Range (-1, 1), Random.Range (-1, 1), Random.Range (-1, 1));
		rotationSpeed = Random.Range (50, 300);
		
		transform.localScale += new Vector3(Random.Range (MIN_SIZE, MAX_SIZE), Random.Range (MIN_SIZE, MAX_SIZE), Random.Range (MIN_SIZE, MAX_SIZE));
	}
	
	void Update () {
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
		target = (transform.position - center.position).normalized * radius + center.position;
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * radiusSpeed);
	}
}