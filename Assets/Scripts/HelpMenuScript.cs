using UnityEngine;
using System.Collections;

public class HelpMenuScript : MonoBehaviour {

	//hide on mouse
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
	}
}
