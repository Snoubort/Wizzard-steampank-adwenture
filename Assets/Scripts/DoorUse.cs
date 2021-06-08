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
                    GeneratePlayerScils();
                    PlayerPrefs.SetInt("LevelIndex", 1);
                    SceneManager.LoadScene("Level1");
                    ActivatedKey = false;
                }
                if (levelIndex == "BoilerEnter")
                {
                    GeneratePlayerScils();
                    SceneManager.LoadScene("Boilers");
                    ActivatedKey = false;
                }
                if (levelIndex == "BoilerExit")
                {
                    GeneratePlayerScils();
                    PlayerPrefs.SetInt("LevelIndex", 2);
                    SceneManager.LoadScene("Level1");
                    ActivatedKey = false;
                }

                if (levelIndex == "PoolEnter")
                {
                    GeneratePlayerScils();
                    PlayerPrefs.SetInt("LevelIndex", 3);
                    SceneManager.LoadScene("Pool");
                    ActivatedKey = false;
                }

                if (levelIndex == "PoolExit")
                {
                    GeneratePlayerScils();
                    PlayerPrefs.SetInt("LevelIndex", 4);
                    SceneManager.LoadScene("Level1");
                    ActivatedKey = false;
                }

                if (levelIndex == "Exit")
                {
                    GeneratePlayerScils();
                    PlayerPrefs.SetInt("LevelIndex", 5);
                    SceneManager.LoadScene("MainMenu");
                    ActivatedKey = false;
                }

            }         
        }
    }

    void GeneratePlayerScils()
    {
        PlayerPrefs.SetInt("HP", 200);
        PlayerPrefs.SetInt("Energy", 200);
    }
}
