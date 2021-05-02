using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guidance : MonoBehaviour
{
    public SceneManager sm;

    public void open()
    {
        gameObject.SetActive(true);

    }
    public void close()
    {
        gameObject.SetActive(false);
        sm.open();
    }

        
}
