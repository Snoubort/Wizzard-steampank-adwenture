using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class BoilersChangeTemp : MonoBehaviour
{
    public Text Boiler;
    public Text BoilerTemp;
    public Text ChosenItem;
    public Text EnergyUsed;
    public void TempChange()
    {
        var c = 1;
        var m = 1;
        var temp = Convert.ToInt32(BoilerTemp.text);
        if (!(Convert.ToInt32(EnergyUsed.text) < c * m) && PlayerPrefs.GetInt("Energy") >= Convert.ToInt32(EnergyUsed.text))
        {
            if (ChosenItem.text == "Inferno")
                temp = temp + Convert.ToInt32(EnergyUsed.text);
            if (ChosenItem.text == "Nefelhame")
                temp = temp - Convert.ToInt32(EnergyUsed.text);
            PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("Energy") - Convert.ToInt32(EnergyUsed.text));
        }

        BoilerTemp.text = temp.ToString();
        Boiler.text = "T = " + temp.ToString() + " C";
    }
}
