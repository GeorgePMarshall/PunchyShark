using UnityEngine;
using System.Collections;

public class newWater : MonoBehaviour {

    Vector3 startPosition;

	void Start ()
    {
        startPosition = transform.position;
	}
	
	void Update ()
    {
        //move water up and down
        transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin((Time.time + (transform.position.x * 0.3f)) * 0.9f ) * 0.2f , startPosition.z);
	}
}
