using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]bool mute = false;

    [SerializeField]int score;
    [SerializeField]int highScore;

    [SerializeField]Sprite muteIcon;
    [SerializeField]Sprite unMuteIcon;
    

    //load from player prefs
    void Start()
    {
        mute = PlayerPrefs.GetInt("mute", 0) == 1;
        highScore = PlayerPrefs.GetInt("highScore", 0);
        UpdateMuteIcon();
    }

    //save to player prefs on close
    void OnDestroy()
    {
        PlayerPrefs.SetInt("mute", mute ? 1 : 0);
        Time.timeScale = 1;
        if (score > highScore)
            PlayerPrefs.SetInt("highScore", (int)score);
    }

    
    void UpdateMuteIcon()
    {
        if (mute)
            transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = muteIcon;
        else
            transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = unMuteIcon;
    }

    //open menu
    public void MenuPressed()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //close menu
    public void ResumedPressed()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    //switch to main menu
    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //mute audio
    public void MutePressed()
    {
        mute = !mute;
        UpdateMuteIcon();
        if (mute)
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
           
    }

    //show help window
    public void HelpPressed()
    {
        transform.FindChild("HelpMenu").gameObject.SetActive(true);
    }

    //update score display
    public void SetScore(int a_score)
    {
        score = a_score;

        transform.FindChild("Score").GetComponent<Text>().text = "Score: " + score.ToString();
    }




}
