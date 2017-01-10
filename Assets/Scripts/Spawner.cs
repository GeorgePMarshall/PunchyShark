using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	//Private Variables
	private Vector3[] spawnlocations = new Vector3[2];
	private Vector3[] targetLocations = new Vector3[2];
    

	private float startingFishTimer = 0.6f;
	private float fishTimer;
	private float fishMin;
	private float fishMax;

	private float startingSharkTimer = 5;
	private float sharkTimer;
	private float sharkMin;
	private float sharkMax;

    private float startingPiraTimer = 3f;
    private float piraTimer;
    private float piraMin;
    private float piraMax;

    //Public Variables
    [SerializeField]
	int currentScore;

	public GameObject fish;
	public GameObject shark;
	public GameObject pira;

    public GameObject targetlocation1, targetLocation2;
	
	public bool spawnSharks;
	public bool spawnFish;
    public bool spawnPira;

    public Material[] materials = new Material[4];

    void Start()
	{
		fishTimer = startingFishTimer;
		sharkTimer = startingSharkTimer;
		piraTimer = startingPiraTimer;

        //Setting where the fish spawn
        //Left
        spawnlocations[0] = transform.position;
		spawnlocations[0].x += -15;

		//Right
		spawnlocations[1] = transform.position;
		spawnlocations[1].x += 15;

		targetlocation1 = transform.GetChild(0).gameObject;
		targetLocation2 = transform.GetChild(1).gameObject;
	}

	void Update()
	{
		targetLocations[0] = targetlocation1.transform.position;
		targetLocations[1] = targetLocation2.transform.position;


        //Spawns Fish
		if (spawnFish)
		{
			fishTimer -= Time.deltaTime;

			if (fishTimer <= 0)
			{
				int chance = FiftyChance();
                int texture = Poop();
                GameObject newFish = Instantiate(fish, spawnlocations[chance], transform.rotation) as GameObject;
                newFish.transform.GetChild(0).GetComponent<MeshRenderer>().material = materials[texture];
                newFish.transform.GetChild(1).GetComponent<MeshRenderer>().material = materials[texture];
                newFish.GetComponent<Fish>().targetLocation = targetLocations[chance];
				fishTimer = startingFishTimer;
				startingFishTimer *= 1;
			}
		}

        //Spawning Sharks
		if (spawnSharks)
		{
            sharkTimer -= Time.deltaTime;

            if (sharkTimer <= 0)
            {
                int chance = FiftyChance();
                GameObject newShark = Instantiate(shark, spawnlocations[chance], transform.rotation) as GameObject;
                newShark.GetComponent<Fish>().targetLocation = targetLocations[chance];
                sharkTimer = startingSharkTimer;
                
                //Dampning
                if (startingSharkTimer <= 0.7)
                {
                    startingSharkTimer *= 0.99f;

                    if (startingSharkTimer <= 0.4f)
                    {
                        startingSharkTimer = 0.4f;
                    }
                }
                else
                {
                    startingSharkTimer *= 0.9f;
                }
            }
        }

        //Spawning Piras
        if (spawnPira)
        {
            piraTimer -= Time.deltaTime;
            
            if (piraTimer <= 0 )
            {
                int chance = FiftyChance();
                GameObject newPira = Instantiate(pira, spawnlocations[chance], transform.rotation) as GameObject;
                newPira.GetComponent<Fish>().targetLocation = targetLocations[chance];
                piraTimer = startingPiraTimer;
                startingPiraTimer = Random.Range(1.5f, 3);

            }
        }
	}

	int FiftyChance()
	{
		return Random.Range(0, 2);
	}

    int Poop()
    {
        return Random.Range(0, 4);
    }


	void OnDrawGizmos()
	{
		Gizmos.DrawCube(targetLocations[0], new Vector3(1, 1, 1));
		Gizmos.DrawCube(targetLocations[1], new Vector3(1, 1, 1));
	}
}
