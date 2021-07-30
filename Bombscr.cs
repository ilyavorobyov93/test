using UnityEngine;

public class Bombscr : MonoBehaviour
{
    public bool _bombbool;
    private Camera _camera;
    private Animator _anim;
    private float Timeclock;

    public AudioSource bombClick;
    public AudioSource bombmBang;
    void Awake()
    {
        _bombbool = true;
        Timeclock = 0.7f;
        _camera = Camera.main;
        _anim = GetComponent<Animator>();
        Destroy(gameObject, 10);
        Invoke("Deletebomb", 9);
    }
    public void OnMouseDrag()
    {
        if (Time.timeScale == 1)
        {
            bombClick.Play();
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = _camera.ScreenToWorldPoint(touch.position);
            touchPosition.z = gameObject.transform.position.z;
            transform.position = touchPosition;
            _anim.SetBool("bombact", true);
            Timeclock -= Time.deltaTime;
            if (Timeclock <= 0f)
            {
                bombmBang.Play();
                _anim.SetBool("bombbang", true);
                Invoke("BombBang", 1);
            }
        }
    }
    void BombBang()
    {
         _camera.GetComponent<GameManager>().bombCheck = true;
    }
    void Deletebomb()
    {
        _anim.SetBool("delete", true);
    }
}
