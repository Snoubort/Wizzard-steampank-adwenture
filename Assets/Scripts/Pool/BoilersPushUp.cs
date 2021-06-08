using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoilersPushUp : MonoBehaviour
{
    public Text Boiler;
    public Text Boiler1Temp;
    public Text Boiler2Temp;
    public Text Boiler3Temp;
    public Text ChosenItem;
    public GameObject floor;
    public Text EnergyUsed;
    public int NumberOfBoiler;
    public int ToUp;
    private int m = 2;
    private int c = 1;

    public void ControlTemp()
    {
        var temp = TakeTemp();
        temp = ChangeTemp(temp);

        if ((Convert.ToInt32(EnergyUsed.text) >= c * m) && 
            PlayerPrefs.GetInt("Energy") >= Convert.ToInt32(EnergyUsed.text))
            ChangeTempTextvalue(temp);

        MovePlatform(temp);

        if (IsOverhiting())
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    bool IsOverhiting()
    {
        var Temp1 = Convert.ToInt32(Boiler1Temp.text);
        var Temp2 = Convert.ToInt32(Boiler2Temp.text);
        var Temp3 = Convert.ToInt32(Boiler3Temp.text);

        return Temp1 + Temp2 + Temp3 > BoilerUpGen.MaxSumm+100;
    }

    void MovePlatform(int temp)
    {
        if (NumberOfBoiler == 1)
            ToUp = BoilerUpGen.UpRange1;
        if (NumberOfBoiler == 2)
            ToUp = BoilerUpGen.UpRange2;
        if (NumberOfBoiler == 3)
            ToUp = BoilerUpGen.UpRange3;

        if (temp < ToUp)
        {
            floor.transform.position = new Vector3(floor.transform.position.x, -7f, floor.transform.position.z);
        }
        if (temp == ToUp)
        {
            floor.transform.position = new Vector3(floor.transform.position.x, -5f, floor.transform.position.z);
        }
    }


    int ChangeTemp(int temp)
    {
        if (ChosenItem.text == "Inferno")
            temp = temp + Convert.ToInt32(EnergyUsed.text) / (c * m);
        if (ChosenItem.text == "Nefelhame")
            temp = temp - Convert.ToInt32(EnergyUsed.text) / (c * m);

        PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("Energy") - Convert.ToInt32(EnergyUsed.text));
        return temp;
    }

    int TakeTemp()
    {
        var temp = 0;
        if (NumberOfBoiler == 1)
            temp = Convert.ToInt32(Boiler1Temp.text);
        if (NumberOfBoiler == 2)
            temp = Convert.ToInt32(Boiler2Temp.text);
        if (NumberOfBoiler == 3)
            temp = Convert.ToInt32(Boiler3Temp.text);

        return temp;
    }

    void ChangeTempTextvalue(int temp)
    {
        if (NumberOfBoiler == 1)
            Boiler1Temp.text = temp.ToString();   
        if (NumberOfBoiler == 2)
            Boiler2Temp.text = temp.ToString();
        if (NumberOfBoiler == 3)
            Boiler3Temp.text = temp.ToString();
        Boiler.text = "T = " + temp.ToString() + " C";
    }
}
