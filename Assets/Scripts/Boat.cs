using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

    public int score;
    public int lives = 3;

    [SerializeField]GameObject menu;
    [SerializeField]GameObject[] life;


    Vector3 from = new Vector3(-3f, 90f, -1f);
    Vector3 to = new Vector3(3f, 90f, 1f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float t = (Mathf.Sin(Time.time * Mathf.PI * 0.5f) + 1.0f) / 2.0f;
        transform.eulerAngles = Vector3.Lerp(from, to, t);

        if (lives <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.transform.tag)
        {
            case "Fish":
                score += 1;
                menu.GetComponent<InGameMenu>().SetScore(score);
                break;
            case "Shark":
                subtractLife();
                other.GetComponent<Collider>().enabled = false;
                break;
            case "Pira":
                subtractScore();
                break;
            default:
                break;
        }
    }

    void subtractLife()
    {
        lives -= 1;
        life[lives].SetActive(false);
        transform.position = transform.position + new Vector3(0, -0.1f, 0);
    }

    void subtractScore()
    {
        if (score - 3 < 0 )
            score = 0;
        else
            score -= 3;
    }
}
