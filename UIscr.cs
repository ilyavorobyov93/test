using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIscr : MonoBehaviour
{
    public GameObject StartPanel, StartButt, SoundButton;
    private Animator _anim1;
    private Animator _anim2;
    private Animator _anim3;
    [SerializeField] Text RecordText;
    [SerializeField] AudioSource _startSound;

    void Awake()
    {
        RecordText.text = PlayerPrefs.GetInt("record").ToString();
        _anim1 = StartPanel.GetComponent<Animator>();
        _anim2 = StartButt.GetComponent<Animator>();
        _anim3 = SoundButton.GetComponent<Animator>();
    }
    public void LoadGame()
    {
        StartCoroutine(StartButton());
    }
    IEnumerator StartButton()
    {
        _startSound.Play();
        _anim1.SetBool("start", true);
        _anim2.SetBool("start", true);
        _anim3.SetBool("start", true);

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
}
