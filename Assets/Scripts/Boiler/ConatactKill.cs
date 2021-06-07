using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConatactKill : MonoBehaviour
{
    public Text BoilTemp;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && BoilTemp.text != "0")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("HP") - 20);                   
        }

        if(PlayerPrefs.GetInt("HP") == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
