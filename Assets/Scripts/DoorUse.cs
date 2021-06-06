using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorUse : MonoBehaviour
{
    public GameObject text;
    public bool ActivatedKey = false;
    public void OpenText()
    {
        text.gameObject.SetActive(true);
    }
    public void CloseText()
    {
        text.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ActivatedKey = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OpenText();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CloseText();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OpenText();
            if (ActivatedKey)
            {
                SceneManager.LoadScene("Boilers");
                ActivatedKey = false;
            }         
        }
    }




}
