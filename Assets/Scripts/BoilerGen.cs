using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
    public static System.Random rnd = new System.Random(DateTime.Now.Millisecond);
    public static bool[] boilWay = new bool[12];
    public static int[] BoilNumbers = new int[12];
    // Start is called before the first frame update
    void Start()
    {
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

        var From3to4 = colum3 % 3 - colum4 % 3;
        if (From3to4 > 0)
        {
            for (var i = 1; i <= From3to4; i++)
            {
                boilWay[colum4 + i] = true;
            }
        }
        if (From3to4 < 0)
        {
            for (var i = 1; i <= Math.Abs(From3to4); i++)
            {
                boilWay[colum4 - i] = true;
            }
        }

        for (var i = 0; i < 12; i++)
        {
            BoilNumbers[i] = -1;
        }

        for (var i = 0; i < 12; i++)
        {
            if(boilWay[i])
                BoilNumbers[i] = 1;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
