using System;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text ChosenItem;
    public Text NextItem;
    public Text PreviousItem;
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
}
