using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour
{
	private Type currentType;
	private Rigidbody body;
	private float randomYHeight;
	private Vector3 m_targetLocation;
	[HideInInspector]
	public Vector3 targetLocation;

    [SerializeField]GameObject splash;

	public enum Type
	{
		COMMON,
		SHARK,
	}

	// Use this for initialization
	void Start()
	{
		//Setting rigidBody
		body = GetComponent<Rigidbody>();
		
		//Setting random height
		randomYHeight = Random.Range(2, 4);
		randomYHeight += Random.value;
		randomYHeight -= 2;

		//Setting random y Height to current position
		Vector3 temp = targetLocation;
		temp.y = randomYHeight + targetLocation.y;
		m_targetLocation = temp;
		body.AddForce(m_targetLocation - transform.position, ForceMode.Impulse);

		Invoke("Kill", 3);
	}

	// Update is called once per frame
	void Update()
	{
		transform.LookAt(body.velocity);
	}
    
	void Kill()
	{
		Destroy(this.gameObject);
	}

    //gets rid of fish when clicked
	void OnMouseDown()
	{
		body.AddForce((targetLocation - transform.position) * 300);
        GetComponent<AudioSource>().Play();
        GetComponent<Collider>().enabled = false;
        Instantiate(splash, transform.position, Quaternion.identity);
    }
}
