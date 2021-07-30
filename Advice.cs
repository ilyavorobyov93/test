using UnityEngine;

public class Advice : MonoBehaviour
{
    public GameObject AdviceController, AdviceTime, AdviceBomb, PauseButt;

    void Start()
    {
        if (!PlayerPrefs.HasKey("HowToPlay"))
        {
            PauseButt.SetActive(false);
            AdviceController.SetActive(true);
            PlayerPrefs.SetInt("HowToPlay", 1);
            Time.timeScale = 0;
        }
    }
    public void ClosePanelControll()
    {
        AdviceController.SetActive(false);
        AdviceTime.SetActive(true);

    }
    public void ClosePanelTime()
    {
        Time.timeScale = 1;
        PauseButt.SetActive(true);
        AdviceTime.SetActive(false);
    }
    public void ClosePanelBomB()
    {
        Time.timeScale = 1;
        PauseButt.SetActive(true);
        AdviceBomb.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (!PlayerPrefs.HasKey("BombAdv") && GameObject.FindWithTag("bomb") == true)
        {   
            PauseButt.SetActive(false);
            AdviceBomb.SetActive(true);
            PlayerPrefs.SetInt("BombAdv", 1);
            Time.timeScale = 0;
        }
    }
}
