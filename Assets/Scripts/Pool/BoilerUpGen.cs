using System;
using UnityEngine;
using UnityEngine.UI;

public class BoilerUpGen : MonoBehaviour
{
    public static int UpRange1;
    public static int UpRange2;
    public static int UpRange3;
    public static int MaxSumm;
    public Text NeedToUP1;
    public Text NeedToUP2;
    public Text NeedToUP3;
    // Start is called before the first frame update
    void Start()
    {
        UpRange1 = BoilerGen.rnd.Next(1, 40);
        if(UpRange1 == 20)
            UpRange1 = BoilerGen.rnd.Next(20, 40);

        UpRange3 = UpRange1;

        UpRange2 = BoilerGen.rnd.Next(20, 40);
        if (UpRange2 == 20)
            UpRange2 = BoilerGen.rnd.Next(20, 40);

        MaxSumm = UpRange1 + UpRange2 + 20;

        NeedToUP1.text = UpRange1.ToString();
        NeedToUP2.text = UpRange2.ToString();
        NeedToUP3.text = UpRange3.ToString();
    }
}
