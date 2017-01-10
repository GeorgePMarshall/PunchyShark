using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    Vector3 from = new Vector3(-2f, 270f, 90f);
    Vector3 to = new Vector3(2f, 270f, 90f);
    float rand;

    void Start ()
    {
        rand = Random.value;
	}
	
	void Update ()
    {
        //tilt water back and forth
        float t = (Mathf.Sin(Time.time + rand * Mathf.PI * 0.5f) + 1.0f) / 2.0f;
        transform.eulerAngles = Vector3.Lerp(from, to, t);
    }
}
