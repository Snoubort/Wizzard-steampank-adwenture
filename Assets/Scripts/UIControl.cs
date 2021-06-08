using System;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text ChosenItem;
    public Text NextItem;
    public Text PreviousItem;
    public Text EnergyUsed;
    public Button ButtonDown;
    public void ToNextItem()
    {
        if(ChosenItem.text == "Inferno")
        {
            ChosenItem.text = "Nefelhame";
            NextItem.text = "Inferno";
            PreviousItem.text = "Inferno";
            return;
        }

        if (ChosenItem.text == "Nefelhame")
        {
            ChosenItem.text = "Inferno";
            NextItem.text = "Nefelhame";
            PreviousItem.text = "Nefelhame";
            return;
        }

    }

    public void ToPreviousItem()
    {
        if (ChosenItem.text == "Inferno")
        {
            ChosenItem.text = "Nefelhame";
            NextItem.text = "Inferno";
            PreviousItem.text = "Inferno";
            return;
        }

        if (ChosenItem.text == "Nefelhame")
        {
            ChosenItem.text = "Inferno";
            NextItem.text = "Nefelhame";
            PreviousItem.text = "Nefelhame";
            return;
        }

    }

    public void EnergyUp()
    {
        EnergyUsed.text = (Convert.ToInt32(EnergyUsed.text) + 1).ToString();
        if(Convert.ToInt32(EnergyUsed.text) > 1)
            ButtonDown.gameObject.SetActive(true);
    }

    public void EnergyDown()
    {
        EnergyUsed.text = (Convert.ToInt32(EnergyUsed.text) - 1).ToString();
        if (Convert.ToInt32(EnergyUsed.text) <= 1)
            ButtonDown.gameObject.SetActive(false);
    }
}
