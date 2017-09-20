using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTest : MonoBehaviour {
	[SerializeField]
	private float Xmin;
	[SerializeField]
	private float Ymin;
	[SerializeField]
	private float Xmax;
	[SerializeField]
	private float Ymax;



	public GameObject player; 

	//private Vector3 offset; 
	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (player.transform.position.x, Xmin, Xmax), Mathf.Clamp (player.transform.position.y, Ymin, Ymax), transform.position.z);
	}
}
