using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {

	private float cSpeed;
	private Rigidbody cRigid;
	private bool cInAir;
	// Use this for initialization
	void Start () {
		cInAir = false;
		cRigid = gameObject.GetComponent<Rigidbody>();
		cSpeed = Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float locVertTrans = Input.GetAxis ("Vertical") * (cSpeed*4);
		float locHorzTrans = Input.GetAxis ("Horizontal") * (cSpeed*4);

		gameObject.transform.Translate (locVertTrans,0,-locHorzTrans);

		if(Input.GetKeyDown("space") && !cInAir){
			cRigid.AddForce(0,250.0f,0);
			cInAir = true;
		}
		if(cRigid.velocity.y == 0){
			cInAir = false;
		}
		Debug.Log(cRigid.velocity.y);
		if(gameObject.transform.position.y < -20){
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
