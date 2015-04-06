using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour {

	private bool shown;
	
	public GameObject sphere;
	public Button toggle;
	public Text toggleText;
	
	private ArrayList objs;

	private float R;
	private float G;
	private float B;

	// Use this for initialization
	void Start () {
		shown = true;
		objs = new ArrayList();
		
		R = 0f;
		G = 0f;
		B = 0f;
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
			toggleText.text = ">";
		}
		else {	// show it
			gameObject.SetActive(true);
			shown = true;
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
	
	/*
	*	Colour change
	*/
	public void RChange(float value)
	{
		R = value;
		ColourChange();
	}
	public void GChange(float value)
	{
		G = value;
		ColourChange();
	}
	public void BChange(float value)
	{
		B = value;
		ColourChange();
	}
	
	public void ColourChange() 
	{
		foreach (GameObject obj in objs)
		{
			obj.transform.SendMessage("ChangeColour", new Color(R/255, G/255, B/255));
		}
	}
}
