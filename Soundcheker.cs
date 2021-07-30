using UnityEngine;
using UnityEngine.UI;

public class Soundcheker : MonoBehaviour
{
    public GameObject SoundButton;

    public Sprite SoundOn;
    public Sprite SoundOff;

    private int SoundCheck;
    void Awake()
    {
        if (PlayerPrefs.HasKey("SoundChange"))
        {
            SoundCheck = PlayerPrefs.GetInt("SoundChange");
            if (SoundCheck == 0)
            {
                AudioListener.volume = 1;
                SoundButton.GetComponent<Image>().sprite = SoundOn;
            }
            else if (SoundCheck == 1)
            {
                AudioListener.volume = 0;
                SoundButton.GetComponent<Image>().sprite = SoundOff;
            }
        }
        else
        {
            PlayerPrefs.SetInt("SoundChange", 0);
            SoundButton.GetComponent<Image>().sprite = SoundOn;
        }
    }
    public void SoundChange()
    {
        SoundCheck = PlayerPrefs.GetInt("SoundChange");
        if (SoundCheck == 1)
        {
            AudioListener.volume = 1;
            SoundButton.GetComponent<Image>().sprite = SoundOn;
            PlayerPrefs.SetInt("SoundChange", 0);
        }
        if (SoundCheck == 0)
        {
            AudioListener.volume = 0;
            SoundButton.GetComponent<Image>().sprite = SoundOff;
            PlayerPrefs.SetInt("SoundChange", 1);
        }
    }


    
}
