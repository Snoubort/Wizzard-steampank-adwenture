using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject BoilExit;

    public float speed = 20.0f;
    public bool ActivatedKey = false;
    private Rigidbody2D rigidBody2D;
    private bool faceRight = true;
    private bool OnFlore = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        if(PlayerPrefs.GetInt("BoilExit") == 1)
        {
            transform.position = BoilExit.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        rigidBody2D.MovePosition(rigidBody2D.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && OnFlore)
        {
            OnFlore = false;
            rigidBody2D.AddForce(Vector2.up * 8000);
        }

        if (moveX > 0 && !faceRight)
            flip();
        else if (moveX < 0 && faceRight)
            flip();

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
}
