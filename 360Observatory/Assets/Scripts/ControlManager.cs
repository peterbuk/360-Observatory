using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour {

	private float SPAWN_RATE = 1.0f;	// how often to spawn an object
	private float timer;
	private bool active;
	
	public GameObject sphere;
	public Button toggle;
	public Text toggleText;

	// Use this for initialization
	void Start () {
		timer = SPAWN_RATE;
		active = true;
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
	
	
	
	/***************************************************
	*				Button Events
	****************************************************/
	
	/*
	*	Show or hide the control panel
	*/
	public void TogglePanel()
	{
		if (active) {	// minimize it
			gameObject.SetActive(false);
			active = false;
			toggle.transform.Translate (-210, 0, 0);
			toggleText.text = ">";
		}
		else {	// show it
			gameObject.SetActive(true);
			active = true;
			toggle.transform.Translate (210, 0, 0);
			toggleText.text = "<";
		}
	}
	
	/*
	*	Turn a value down.
	*	
	*/
	public void ValueDown(int type)
	{
	
	}
	
	public void ValueUp(int type)
	{
	
	}
	
	
}
