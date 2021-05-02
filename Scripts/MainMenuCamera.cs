using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    private int check;
    public GameObject Volume;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        check = PlayerPrefs.GetInt("Graphic");
        if (check == 1)
        {
            Volume.SetActive(true);
        }
        else
        {
            Volume.SetActive(false);
        }
    }


}
