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

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;


	public GameObject player; 

	//private Vector3 offset; 
	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (Mathf.Clamp (posX, Xmin, Xmax), Mathf.Clamp (posY, Ymin, Ymax), transform.position.z);
	}
}
