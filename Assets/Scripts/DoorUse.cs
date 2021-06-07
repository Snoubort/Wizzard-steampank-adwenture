using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorUse : MonoBehaviour
{
    public GameObject text;
    public bool ActivatedKey = false;
    public string levelIndex;
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
                if (levelIndex == "TutorialExit")
                {
                    PlayerPrefs.SetInt("LevelIndex", 1);
                    SceneManager.LoadScene("Level1");
                    ActivatedKey = false;
                }
                if (levelIndex == "BoilerEnter")
                {
                    SceneManager.LoadScene("Boilers");
                    ActivatedKey = false;
                }
                if (levelIndex == "BoilerExit")
                {
                    PlayerPrefs.SetInt("LevelIndex", 2);
                    SceneManager.LoadScene("Level1");
                    ActivatedKey = false;
                }

                if (levelIndex == "PoolEnter")
                {
                    PlayerPrefs.SetInt("LevelIndex", 3);
                    SceneManager.LoadScene("Pool");
                    ActivatedKey = false;
                }

                if (levelIndex == "PoolExit")
                {
                    PlayerPrefs.SetInt("LevelIndex", 4);
                    SceneManager.LoadScene("Level1");
                    ActivatedKey = false;
                }

            }         
        }
    }
}
