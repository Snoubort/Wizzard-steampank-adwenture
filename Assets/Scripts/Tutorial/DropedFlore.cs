using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropedFlore : MonoBehaviour
{
    public Text Boiler;
    public Text BoilerTemp;
    public GameObject floor;
    public Text EnergyUsed;
    public Text ChosenItem;
    private void Start()
    {
        Boiler.text = "T = 20 C";
        BoilerTemp.text = "20";
    }

    public void DropFloor()
    {
        var c = 2;
        var m = 10;
        var temp = Convert.ToInt32(BoilerTemp.text);

        if (!(Convert.ToInt32(EnergyUsed.text) < c * m) && PlayerPrefs.GetInt("Energy") >= Convert.ToInt32(EnergyUsed.text))
        {
            if (ChosenItem.text == "Inferno")
                temp = temp + Convert.ToInt32(EnergyUsed.text) / (c * m);
            if (ChosenItem.text == "Nefelhame")
                temp = temp - Convert.ToInt32(EnergyUsed.text) / (c * m);
            PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("Energy") - Convert.ToInt32(EnergyUsed.text));
        }

        BoilerTemp.text = temp.ToString();
        Boiler.text = "T = " + temp.ToString() + " C";
        if (temp == 10)
            floor.transform.position = new Vector3(floor.transform.position.x, -7.2f, floor.transform.position.z);
        if (Convert.ToInt32(BoilerTemp.text) >= 40)
            SceneManager.LoadScene("GameOver"); 

    }
}
