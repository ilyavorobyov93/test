using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] GameBlocks = new GameObject[25];
    public GameObject[] Bombs = new GameObject[5];

    [SerializeField] GameObject RedBox, GreenBox, BlueBox, PurpBox, YellowBox;

    public GameObject PauseButt;
    public GameObject PausePanel;
    public GameObject DefeatPanel;
    public GameObject BombBangPanel;
    public GameObject SoundButton;

    [SerializeField] Sprite SoundOn;
    [SerializeField] Sprite SoundOff;
    [SerializeField] Text ResultText;
    [SerializeField] Text RecordText;
    [SerializeField] Text TimerText;

    public AudioSource restartSound;
    public AudioSource buttonSound;
    public AudioSource looseSound;
    public AudioSource endsTime;

    public bool bombCheck;
    private float minX = -1.84f;
    private float maxX = 1.85f;
    private float minY = 1.0f;
    private float maxY = -3.65f;
    private int randBlock;
    private int numberOfBlocks;
    private int SoundCheck;

    private float Timer;
    private float Timeclock;

    bool _endtimesound;

    private int currentLVL;
    void Start()
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
        _endtimesound = true;
        bombCheck = false;
        MixBox();
        Time.timeScale = 1;
        numberOfBlocks = 2;
        currentLVL = 0;
        BlockRespawnerOnAwake();
        Timer = 8f;
        RecordText.text = PlayerPrefs.GetInt("record").ToString();
    }
    void FixedUpdate()
    {
        Timeclock = (float)(Time.timeSinceLevelLoad - Timer) * -1;
        TimerText.text = Timeclock.ToString("0.00") + " ñ";

        if (GameObject.FindWithTag("blueblock") == false && GameObject.FindWithTag("purpblock") == false && GameObject.FindWithTag("redblock") == false && GameObject.FindWithTag("yellblock") == false && GameObject.FindWithTag("greenblock") == false)
        {
            currentLVL++;
            Timer += (numberOfBlocks + 0.3f);
            ResultText.text = currentLVL.ToString();
            BlockRespawner();
        }
        if (Timeclock > 3f)
        {
            endsTime.Stop();
        }
        if (Timeclock < 3f && _endtimesound == true)
        {
            endsTime.Play();
            _endtimesound = false;
            Invoke("EndsoundChange", 0.5f);
        }
        if (Timeclock < 0.02)
        {
            TimerText.text = "0";
            TimeOver();
        }
        if (bombCheck == true)
        {
            BombBang();
        }
    }
    void BlockRespawner()
    {
        buttonSound.Play();
        if (currentLVL <= 16)
        {
            numberOfBlocks += Random.Range(0, 2);
        }
        else if (currentLVL > 16 && currentLVL <= 20)
        {
            numberOfBlocks += 0;
        }
        if (currentLVL > 10 && Timer > 10)
        {
            numberOfBlocks += 1;
        }
        for (int i = 1; i <= numberOfBlocks; i++)
        {
            randBlock = Random.Range(0, 25);
            Instantiate(GameBlocks[randBlock], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), GameBlocks[randBlock].transform.position.z), Quaternion.identity);
        }
        if (Random.Range(0, 3) == 0)
        {
            randBlock = Random.Range(0, 5);
            Instantiate(Bombs[randBlock], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), GameBlocks[randBlock].transform.position.z), Quaternion.identity);
        }
    }
    void BlockRespawnerOnAwake()
    {
        randBlock = Random.Range(0, 25);
        Instantiate(GameBlocks[randBlock], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), GameBlocks[randBlock].transform.position.z), Quaternion.identity);
        randBlock = Random.Range(0, 25);
        Instantiate(GameBlocks[randBlock], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), GameBlocks[randBlock].transform.position.z), Quaternion.identity);
        Instantiate(GameBlocks[4], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), GameBlocks[4].transform.position.z), Quaternion.identity);
        numberOfBlocks += 1;
    }
    void MixBox()
    {
        Vector3 Box1Pos = new Vector2(-315, 138f);
        Vector3 Box2Pos = new Vector2(-155, 138f);
        Vector3 Box3Pos = new Vector2(0f, 138f);
        Vector3 Box4Pos = new Vector2(155, 138f);
        Vector3 Box5Pos = new Vector2(315, 138f);

        RectTransform RedBox_Rect = RedBox.GetComponent<RectTransform>();
        RectTransform GreenBox_Rect = GreenBox.GetComponent<RectTransform>();
        RectTransform BlueBox_Rect = BlueBox.GetComponent<RectTransform>();
        RectTransform PurpBox_Rect = PurpBox.GetComponent<RectTransform>();
        RectTransform YellowBox_Rect = YellowBox.GetComponent<RectTransform>();

        int RandPos = Random.Range(1, 6);
        if (RandPos == 1)
        {
            RedBox_Rect.anchoredPosition = Box1Pos;
            GreenBox_Rect.anchoredPosition = Box2Pos;
            BlueBox_Rect.anchoredPosition = Box3Pos;
            PurpBox_Rect.anchoredPosition = Box4Pos;
            YellowBox_Rect.anchoredPosition = Box5Pos;
        }
        else if (RandPos == 2)
        {
            RedBox_Rect.anchoredPosition = Box2Pos;
            GreenBox_Rect.anchoredPosition = Box3Pos;
            BlueBox_Rect.anchoredPosition = Box4Pos;
            PurpBox_Rect.anchoredPosition = Box5Pos;
            YellowBox_Rect.anchoredPosition = Box1Pos;
        }
        else if (RandPos == 3)
        {
            RedBox_Rect.anchoredPosition = Box3Pos;
            GreenBox_Rect.anchoredPosition = Box4Pos;
            BlueBox_Rect.anchoredPosition = Box5Pos;
            PurpBox_Rect.anchoredPosition = Box1Pos;
            YellowBox_Rect.anchoredPosition = Box2Pos;
        }
        else if (RandPos == 4)
        {
            RedBox_Rect.anchoredPosition = Box4Pos;
            GreenBox_Rect.anchoredPosition = Box5Pos;
            BlueBox_Rect.anchoredPosition = Box1Pos;
            PurpBox_Rect.anchoredPosition = Box2Pos;
            YellowBox_Rect.anchoredPosition = Box3Pos;
        }
        else
        {
            RedBox_Rect.anchoredPosition = Box5Pos;
            GreenBox_Rect.anchoredPosition = Box1Pos;
            BlueBox_Rect.anchoredPosition = Box2Pos;
            PurpBox_Rect.anchoredPosition = Box3Pos;
            YellowBox_Rect.anchoredPosition = Box4Pos;
        }
    }
    public void PauseButton()
    {
        buttonSound.Play();
        Time.timeScale = 0;
        PauseButt.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        buttonSound.Play();
        Time.timeScale = 1;
        PauseButt.SetActive(true);
        PausePanel.SetActive(false);
    }
    public void GoToMenu()
    {
        buttonSound.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void PlusTimeButt()
    {
        buttonSound.Play();
        Time.timeScale = 1;
        Timer += 4;
        PauseButt.SetActive(true);
        DefeatPanel.SetActive(false);
    }
    public void TimeOver()
    {
        looseSound.Play();
        Time.timeScale = 0;
        PauseButt.SetActive(false);
        DefeatPanel.SetActive(true);
        if (currentLVL >= PlayerPrefs.GetInt("record"))
        {
            PlayerPrefs.SetInt("record", currentLVL);
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
    private void EndsoundChange()
    {
        _endtimesound = true;
    }
    public void BombBang()
    {
        looseSound.Play();
        Time.timeScale = 0;
        PauseButt.SetActive(false);
        BombBangPanel.SetActive(true);
        if (currentLVL >= PlayerPrefs.GetInt("record"))
        {
            PlayerPrefs.SetInt("record", currentLVL);
        }
    }
}    

    
    


