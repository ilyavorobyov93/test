using UnityEngine;

public class BlockScr : MonoBehaviour
{
    private Camera Camera;
    private Collider2D _col;
    private Animator _anim;
    private float _zpos;
    public AudioSource blockSound;
    void Awake()
    {
        _zpos = 1;
        _col = GetComponent<Collider2D>();
        Camera = Camera.main;
        _anim = GetComponent<Animator>();
    }
    public void OnMouseDrag()
    {
        if (Time.timeScale == 1 && (gameObject.CompareTag("blueblock") || gameObject.CompareTag("purpblock") || gameObject.CompareTag("redblock") || gameObject.CompareTag("yellblock") || gameObject.CompareTag("greenblock")))
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.ScreenToWorldPoint(touch.position);
            touchPosition.z = gameObject.transform.position.z;
            transform.position = touchPosition;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bluebox") && gameObject.CompareTag("blueblock"))
        {
            blockSound.Play();
            Invoke("ChangeOrder", 1);
            _col.enabled = false;
            _anim.SetBool("scale", true);
            gameObject.tag = ("blockdown");
            Invoke("DeleteAnim", 10);
        }
        else if (other.gameObject.CompareTag("purpbox") && gameObject.CompareTag("purpblock"))
            {
                blockSound.Play();
                Invoke("ChangeOrder", 1);
                _col.enabled = false;
                _anim.SetBool("scale", true);
                gameObject.tag = ("blockdown");
                Invoke("DeleteAnim", 10);
            }
        else if (other.gameObject.CompareTag("redbox") && gameObject.CompareTag("redblock"))
        {
            blockSound.Play();
            Invoke("ChangeOrder", 1);
            _col.enabled = false;
            _anim.SetBool("scale", true);
            gameObject.tag = ("blockdown");
            Invoke("DeleteAnim", 10);
        }
        else if (other.gameObject.CompareTag("yellbox") && gameObject.CompareTag("yellblock"))
        {
            blockSound.Play();
            Invoke("ChangeOrder", 1);
            _col.enabled = false;
            _anim.SetBool("scale", true);
            gameObject.tag = ("blockdown");
            Invoke("DeleteAnim", 10);
        }
        else if (other.gameObject.CompareTag("greenbox") && gameObject.CompareTag("greenblock"))
        {
            blockSound.Play();
            Invoke("ChangeOrder", 1);
            _col.enabled = false;
            _anim.SetBool("scale", true);
            gameObject.tag = ("blockdown");
            Invoke("DeleteAnim", 10);
        }
    }
    public void ChangeOrder()
    {
        transform.position = transform.position + new Vector3(0f, 0f, _zpos);
    }
    public void DeleteAnim()
    {
        _anim.SetBool("isdelete", true);
        Destroy(gameObject, 0.8f);
    }
}
