using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public float offset;
    public float smoothturn;
    private Vector3 playerposition;
    public Rigidbody2D playerbody;
    private Vector2 ScreenBounds;
    public Transform particulars;
    public RetryMenu Retrymenu;
    public GameObject Volume;

    // Start is called before the first frame update
    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
     
      
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            Retrymenu.loadRetry();
            Retrymenu.SetHighscoreInretry();
        }


        playerposition = new Vector3(player.transform.position.x, 0, 0);
        if (player.transform.localScale.y > 0f)
        {
            playerposition = new Vector3(0, player.transform.position.y - offset, -1);
        }
        else
        {
            playerposition = new Vector3(0, player.transform.position.y - offset, -1);
        }
        Vector3 lastpos=Vector3.Lerp(transform.position, playerposition, smoothturn * Time.deltaTime);
        transform.position = lastpos;

        if (playerbody.velocity.y > 20f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }


        int check = PlayerPrefs.GetInt("Graphic");
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
