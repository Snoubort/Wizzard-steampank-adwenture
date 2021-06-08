using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject BoilExit;
    public GameObject PoolExit;
    public Animator Anim;
    public Slider HP;
    public Slider Energe;

    public float speed = 30.0f;
    public bool ActivatedKey = false;
    private Rigidbody2D rigidBody2D;
    private bool faceRight = true;
    private bool OnFlore = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        // 0 - Tutorial
        //1 - Level1Start
        //2 - BoilerExit
        //3 - PoolEnter
        //4 - PoolExit
        //5 - Exit
        if (PlayerPrefs.GetInt("LevelIndex") == 2)
        {
            transform.position = BoilExit.transform.position;
        }
        if (PlayerPrefs.GetInt("LevelIndex") == 4)
        {
            transform.position = PoolExit.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BarsUpdate();
        MoveLeftRight();

        if (Input.GetKeyDown(KeyCode.UpArrow) && OnFlore)
        {
            OnFlore = false;
            rigidBody2D.AddForce(Vector2.up * 8000);
        }

        if (Input.GetKeyDown(KeyCode.E))
            ActivatedKey = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            OnFlore = true;

    }
    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void MoveLeftRight()
    {
        float moveX = Input.GetAxis("Horizontal");
        rigidBody2D.MovePosition(rigidBody2D.position + Vector2.right * moveX * speed * Time.deltaTime);
        if(moveX != 0)
            Anim.SetBool("IsRun", true);
        else
            Anim.SetBool("IsRun", false);

        if (moveX > 0 && !faceRight)
        {
            flip();
        }  
        else if (moveX < 0 && faceRight)
            flip();
    }
    void BarsUpdate()
    {
        HP.maxValue = PlayerPrefs.GetInt("MaxHP");
        Energe.maxValue = PlayerPrefs.GetInt("MaxEnergy");
        HP.value = PlayerPrefs.GetInt("HP");
        Energe.value = PlayerPrefs.GetInt("Energy");
    }
}
