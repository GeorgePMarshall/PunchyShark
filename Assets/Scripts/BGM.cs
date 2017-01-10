using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	//Singleton for music
    void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

}
