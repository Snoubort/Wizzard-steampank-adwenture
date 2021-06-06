using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class BoilersChangeTemp : MonoBehaviour
{
    public Text Boiler;   
    public void TempPlus()
    {
        Boiler.text = "T = 0 C";
    }
}
