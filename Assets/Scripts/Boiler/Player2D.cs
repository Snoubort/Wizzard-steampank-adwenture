using UnityEngine;
using UnityEngine.UI;

public class Player2D : MonoBehaviour
{
    public Slider HP;
    public Slider Energe;

    public float speed = 20.0f;
    public bool ActivatedKey = false;

    private Rigidbody2D rigidBody2D;
    private Vector2 velocity;
    private bool faceRight = true;
    // Start is called before the first frame update
    void Start()
    {
        GeneratePlayerScils();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BarsUpdate();
        float moveX = Input.GetAxis("Horizontal"); 
        float moveY = Input.GetAxis("Vertical");
        velocity = new Vector2(moveX * speed, moveY * speed);
        rigidBody2D.MovePosition(rigidBody2D.position + velocity * Time.deltaTime);

        if (moveX > 0 && !faceRight)
            flip();
        else if (moveX < 0 && faceRight)
            flip();

        if (Input.GetKeyDown(KeyCode.E))
            ActivatedKey = true;
    }

    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void GeneratePlayerScils()
    {
        PlayerPrefs.SetInt("HP", 200);
        PlayerPrefs.SetInt("Energy", 200);
        HP.value = PlayerPrefs.GetInt("HP");
        Energe.value = PlayerPrefs.GetInt("Energy");
    }

    void BarsUpdate()
    {
        HP.value = PlayerPrefs.GetInt("HP");
        Energe.value = PlayerPrefs.GetInt("Energy");
    }
}
