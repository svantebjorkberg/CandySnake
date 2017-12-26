using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.transform.Rotate(Vector3.forward, 90);

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.Rotate(Vector3.forward, -90);

        }
        gameObject.transform.position -= gameObject.transform.up * Time.deltaTime * Board.speed;
    }
}
