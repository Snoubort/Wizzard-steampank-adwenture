using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropedFlore : MonoBehaviour
{
    public Text Boiler;
    public Text BoilerTemp;
    public GameObject floor;
    public Text ChosenItem;

    public void DropFloor()
    {
        var c = 2;
        var m = 10;
        var temp = Convert.ToInt32(BoilerTemp.text);

        if (ChosenItem.text == "Inferno")
            temp = temp + 20 / (c * m);
        if (ChosenItem.text == "Nefelhame")
            temp = temp - 20 / (c * m);

        PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("Energy") - 20);
        BoilerTemp.text = temp.ToString();
        Boiler.text = "T = " + temp.ToString() + " C";
        if (temp == 15)
            floor.transform.position = new Vector3(floor.transform.position.x, -7.2f, floor.transform.position.z);
        if (Convert.ToInt32(BoilerTemp.text) >= 20)
            SceneManager.LoadScene("GameOver"); 

    }
}
