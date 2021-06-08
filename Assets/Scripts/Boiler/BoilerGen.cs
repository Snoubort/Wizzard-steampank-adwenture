using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoilerGen : MonoBehaviour
{
    public Text Boiler1;
    public Text Boiler2;
    public Text Boiler3;
    public Text Boiler4;
    public Text Boiler5;
    public Text Boiler6;
    public Text Boiler7;
    public Text Boiler8;
    public Text Boiler9;
    public Text Boiler10;
    public Text Boiler11;
    public Text Boiler12;

    public Text BoilerTemp1;
    public Text BoilerTemp2;
    public Text BoilerTemp3;
    public Text BoilerTemp4;
    public Text BoilerTemp5;
    public Text BoilerTemp6;
    public Text BoilerTemp7;
    public Text BoilerTemp8;
    public Text BoilerTemp9;
    public Text BoilerTemp10;
    public Text BoilerTemp11;
    public Text BoilerTemp12;

    public static System.Random rnd = new System.Random(DateTime.Now.Millisecond);
    public static bool[] boilWay = new bool[12];
    public static int[] BoilNumbers = new int[12];
    // Start is called before the first frame update
    void Start()
    {
        var ways = new List<int>();

        for (var i = 0; i < 12; i++)
        {
            boilWay[i] = false;
        }
        for (var i = 0; i <= 3; i++)
        {
            boilWay[i * 3 + rnd.Next(0, 3)] = true;
        }

        var colum1 = -1;
        var colum2 = -1;
        var colum3 = -1;
        var colum4 = -1;
        for (var i = 0; i < 3; i++)
        {
            if (boilWay[i])
                colum1 = i;
        }
        for (var i = 3; i < 6; i++)
        {
            if (boilWay[i])
                colum2 = i;
        }
        for (var i = 6; i < 9; i++)
        {
            if (boilWay[i])
                colum3 = i;
        }
        for (var i = 9; i < 12; i++)
        {
            if (boilWay[i])
                colum4 = i;
        }

        var From1to2 = colum1 - colum2 % 3;
        if (From1to2 > 0)
        {
            for (var i = 1; i <= From1to2; i++)
            {
                boilWay[colum2 + i] = true;
            }
        }
        if (From1to2 < 0)
        {
            for (var i = 1; i <= Math.Abs(From1to2); i++)
            {
                boilWay[colum2 - i] = true;
            }
        }

        var From2to3 = colum2 % 3 - colum3 % 3;
        if (From2to3 > 0)
        {
            for (var i = 1; i <= From2to3; i++)
            {
                boilWay[colum3 + i] = true;
            }
        }
        if (From2to3 < 0)
        {
            for (var i = 1; i <= Math.Abs(From2to3); i++)
            {
                boilWay[colum3 - i] = true;
            }
        }

        boilWay[colum3 % 3 + 8] = true; 

        var maxEnergy = PlayerPrefs.GetInt("MaxEnergy");

        for (var i = 0; i < 12; i++)
        {
            if (boilWay[i])
                ways.Add(i);
        }

        var valueLimit = maxEnergy / ways.Count;

        for (var i = 0; i < 12; i++)
        {
            if (rnd.Next(1, 3) == 1)
                BoilNumbers[i] = rnd.Next(-valueLimit - 20, -valueLimit - 2);
            else
                BoilNumbers[i] = rnd.Next(valueLimit + 2, valueLimit + 20);
        }

        foreach (var index in ways)
        {
            var number = 0;
            if (rnd.Next(1, 3) == 1)
                number = rnd.Next(-valueLimit, -valueLimit +20);
            else
                number = rnd.Next(valueLimit - 20, valueLimit);

            if (index == colum3 % 3 + 8)
            {
                number = maxEnergy;
                break;
            }
                
            BoilNumbers[index] = number;
            maxEnergy = maxEnergy - number;
        }

        Boiler1.text = "T = " + BoilNumbers[0].ToString() + " C";
        Boiler2.text = "T = " + BoilNumbers[1].ToString() + " C";
        Boiler3.text = "T = " + BoilNumbers[2].ToString() + " C";
        Boiler4.text = "T = " + BoilNumbers[3].ToString() + " C";
        Boiler5.text = "T = " + BoilNumbers[4].ToString() + " C";
        Boiler6.text = "T = " + BoilNumbers[5].ToString() + " C";
        Boiler7.text = "T = " + BoilNumbers[6].ToString() + " C";
        Boiler8.text = "T = " + BoilNumbers[7].ToString() + " C";
        Boiler9.text = "T = " + BoilNumbers[8].ToString() + " C";
        Boiler10.text = "T = " + BoilNumbers[9].ToString() + " C";
        Boiler11.text = "T = " + BoilNumbers[10].ToString() + " C";
        Boiler12.text = "T = " + BoilNumbers[11].ToString() + " C";

        BoilerTemp1.text = BoilNumbers[0].ToString();
        BoilerTemp2.text = BoilNumbers[1].ToString();
        BoilerTemp3.text = BoilNumbers[2].ToString();
        BoilerTemp4.text = BoilNumbers[3].ToString();
        BoilerTemp5.text = BoilNumbers[4].ToString();
        BoilerTemp6.text = BoilNumbers[5].ToString();
        BoilerTemp7.text = BoilNumbers[6].ToString();
        BoilerTemp8.text = BoilNumbers[7].ToString();
        BoilerTemp9.text = BoilNumbers[8].ToString();
        BoilerTemp10.text = BoilNumbers[9].ToString();
        BoilerTemp11.text = BoilNumbers[10].ToString();
        BoilerTemp12.text = BoilNumbers[11].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
