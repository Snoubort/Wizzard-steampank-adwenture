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
    public void TempChange()
    {
        var temp = Convert.ToInt32(BoilerTemp.text);
        PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("Energy") - 2);

        if (ChosenItem.text == "Inferno")
            temp = temp + 2;
        if (ChosenItem.text == "Nefelhame")
            temp = temp - 2;

        BoilerTemp.text = temp.ToString();
        Boiler.text = "T = " + temp.ToString() + " C";
    }
}
