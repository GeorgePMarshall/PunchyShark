using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField]bool mute = false;

    [SerializeField]Sprite muteIcon;
    [SerializeField]Sprite unMuteIcon;


    //load from player prefs
    void Start()
    {
        //PlayerPrefs.SetInt("highScore", 0);
        mute = PlayerPrefs.GetInt("mute", 0) == 1;
        transform.FindChild("scoreDisplay").GetComponent<Text>().text = PlayerPrefs.GetInt("highScore", 0).ToString();
        UpdateMuteIcon();
    }

    //save to player prefs
    void OnDestroy()
    {
        PlayerPrefs.SetInt("mute", mute ? 1 : 0);
    }

    //play game
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("main");
    }

    void UpdateMuteIcon()
    {
        if (mute)
            transform.FindChild("Mute").GetComponent<Image>().sprite = muteIcon;
        else
            transform.FindChild("Mute").GetComponent<Image>().sprite = unMuteIcon;
    }

    public void MutePressed()
    {
        mute = !mute;
        UpdateMuteIcon();
        if (mute)
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
    }

    public void HelpPressed()
    {
        transform.FindChild("HelpMenu").gameObject.SetActive(true);
    }
}
