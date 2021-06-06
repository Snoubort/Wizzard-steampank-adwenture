using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject BoilExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerPrefs.GetInt("BoilExit") == 1)
            {
                transform.position = BoilExit.transform.position;
                return;
            }
        }
    }
}
