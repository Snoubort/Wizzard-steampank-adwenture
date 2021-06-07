using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        GeneratePlayerScills();
        PlayerPrefs.SetInt("LevelIndex", 0);
        SceneManager.LoadScene("Tutorial");
    }

    void GeneratePlayerScills()
    {
        PlayerPrefs.SetInt("MaxHP", 200);
        PlayerPrefs.SetInt("MaxEnergy", 200);
        PlayerPrefs.SetInt("HP", 200);
        PlayerPrefs.SetInt("Energy", 200);
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("LevelIndex") == 0)
        {
            SceneManager.LoadScene("Tutorial");
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("MaxHP", 200));
            PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("MaxEnergy", 200));
        }
        if (PlayerPrefs.GetInt("LevelIndex") == 1)
        {
            SceneManager.LoadScene("Level1");
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("MaxHP", 200));
            PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("MaxEnergy", 200));
        }
        if (PlayerPrefs.GetInt("LevelIndex") == 2)
        {
            SceneManager.LoadScene("Level1");
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("MaxHP", 200));
            PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("MaxEnergy", 200));
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
