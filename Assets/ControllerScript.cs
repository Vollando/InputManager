using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Not using else if so any movements can link into another
		if(Input.GetKey(GameManagerScript.GM.forward))
            transform.position += Vector3.forward / 2;
        if (Input.GetKey(GameManagerScript.GM.backward))
            transform.position += Vector3.back / 2;
        if (Input.GetKey(GameManagerScript.GM.left))
            transform.position += Vector3.left / 2;
        if (Input.GetKey(GameManagerScript.GM.right))
            transform.position += Vector3.right / 2; 
        // GetKeyDown on Jump prevents stacking
        if (Input.GetKeyDown(GameManagerScript.GM.jump))
            transform.position += Vector3.up / 2;
    }
}
