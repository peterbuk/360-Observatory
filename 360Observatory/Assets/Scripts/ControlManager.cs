using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour {

	private bool shown;
	
	public GameObject sphere;
	public Button toggle;
	public Text toggleText;
	
	private ArrayList objs;

	// Use this for initialization
	void Start () {
		shown = true;
		objs = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	
	/****************************
	*			Events
	*****************************/
	
	/*
	*	Show or hide the control panel
	*/
	public void TogglePanel()
	{
		if (shown) {	// minimize it
			gameObject.SetActive(false);
			shown = false;
			toggle.transform.Translate (-210, 0, 0);
			toggleText.text = ">";
		}
		else {	// show it
			gameObject.SetActive(true);
			shown = true;
			toggle.transform.Translate (210, 0, 0);
			toggleText.text = "<";
		}
	}
	
	/*
	*	Object change
	*/
	public void ObjChange(float value)
	{
		if (value > objs.Count)
			SpawnObject();
		else if (value < objs.Count)
			DespawnObject();
		
	}
	void SpawnObject()
	{
		GameObject obj = (GameObject) Instantiate (sphere, sphere.transform.position, Quaternion.identity);
		obj.SetActive(true);
		obj.SendMessage("RandomizeMovement");
		objs.Add (obj);
			
		Debug.Log ("Spawning object " + objs.Count);
	}
	void DespawnObject()
	{
		if (objs.Count != 0) {
			Debug.Log ("Despawning object " + objs.Count);
			GameObject obj = (GameObject) objs[objs.Count -1];
			Destroy (obj);
			objs.RemoveAt (objs.Count - 1);
		}
	}
	
	
	/*
	*	Speed change
	*/
	public void SpeedChange(float value)
	{
		foreach (GameObject obj in objs)
		{
			obj.transform.SendMessage("ChangeSpeed", value);
		}
	}
	
	/*
	*	Size change
	*/
	public void SizeChange(float value)
	{
		foreach (GameObject obj in objs)
		{
			obj.transform.SendMessage("ChangeSize", value);
		}
	}

	
}
