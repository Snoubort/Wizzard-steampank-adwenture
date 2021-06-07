using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoilersPushUp : MonoBehaviour
{
    public Text Boiler;
    public Text BoilerTemp;
    public Text Boiler2Temp;
    public Text Boiler3Temp;
    public int ToUp;
    public Text ChosenItem;
    public GameObject floor;

    public void DropFloor()
    {
        var c = 1;
        var m = 2;
        var temp = Convert.ToInt32(BoilerTemp.text);
        
        if (ChosenItem.text == "Inferno")
            temp = temp + 2 / (c * m);
        if (ChosenItem.text == "Nefelhame")
            temp = temp - 2 / (c * m);

        PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("Energy") - 2);
        BoilerTemp.text = temp.ToString();
        Boiler.text = "T = " + temp.ToString() + " C";
        if (temp < ToUp)
            floor.transform.position = new Vector3(floor.transform.position.x, -7f, floor.transform.position.z);
        if (temp == ToUp)
            floor.transform.position = new Vector3(floor.transform.position.x, -5f, floor.transform.position.z);
        if (Convert.ToInt32(BoilerTemp.text) + Convert.ToInt32(Boiler2Temp.text) + Convert.ToInt32(Boiler3Temp.text) > 90)
            SceneManager.LoadScene("GameOver");

    }
}
