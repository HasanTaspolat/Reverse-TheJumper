using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float move = 0f;
    public float speed;
    private Rigidbody2D rigidbody;
    public float jumpspeed = -15f;
    public Transform groundcheckpoint;
    public float groundcheckHeight;
    public LayerMask GroundLayer;
    private bool groundcheck = false;
    private Animator playerEvents;
    private float actualjmp;
    public Transform startrespawn;
    private bool isDeath = false;
    public Sprite MainPlayer;
    public SpriteRenderer spriteRenderer;
    public Color[] backgroundcolor;
    private float ColorChanger;
    public GameObject blockDefault;
    public GameObject redBlock;
    public Transform playerpos;
    private Vector3 ScreenBounds;
    public Camera maincam;
    public GameObject JumpParticle;
    private float score = 0.0f;
    public Text scoretext;
    public GameObject obstacle;
    public GameObject deathParticle;
    public GameObject leftobstacle;
    public Text HighScore;
    public Text RetryText;
    public RetryMenu Retrymenu;




    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //playerEvents = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        initBlocksAtStart();
        StartCoroutine(obstaclespawntimer());
        HighScore.text ="High Score: " + PlayerPrefs.GetInt("Highscore").ToString();


    }

    // Update is called once per frame
    void Update()
    {
        Controller();
        // playerEvents.SetBool("onGround", groundcheck);
        // playerEvents.SetFloat("YaxisSpeed", rigidbody.velocity.y);
        //spriteRenderer.material.color = Color.Lerp(spriteRenderer.material.color, backgroundcolor[0], 5 * Time.deltaTime);
      if(rigidbody.velocity.y < 0 && transform.position.y < 0)
        {
            score = transform.position.y;
        }
        scoretext.text = "Score: " + Mathf.Round(-score).ToString();

        if(-score > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", (int)-score);
            HighScore.text = "High Score: " + Mathf.Round(-score).ToString();
        }
        OutOfScreen();

        RetryText.text = "Score: " + Mathf.Round(-score).ToString();

     
    }
        



    void Controller()
    {
        groundcheck = Physics2D.OverlapCircle(groundcheckpoint.position, groundcheckHeight, GroundLayer);
          
            // Mobile Actions
        
        if(Input.touchCount> 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
            touchpos.z = 0;

                if (touchpos.x > 0)
                {
                   switch(touch.phase)
                {
                    case TouchPhase.Began:
                        speed = 6.9f;
                        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
                        break;
                    case TouchPhase.Stationary:
                        if (speed < 16f)
                        {
                            speed += .21f;
                            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
                        }
                        break;
                    case TouchPhase.Ended:
                        while (speed > 1f)
                        {
                            speed -= .001f;
                            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
                        }
                        break;
                }
                    
                }
                else if (touchpos.x < 0)
            {
                switch(touch.phase)
                { 
                  case TouchPhase.Began:
                        speed = 6.9f;
                        rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
                break;
                    case TouchPhase.Stationary:
                        if(speed < 16f)
                        {
                            speed += .21f;
                            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
                        }
                        
                break;
                    case TouchPhase.Ended:
                        while(speed  > 1f)
                        {
                            speed -= .001f;
                            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
                            
                        }
                        
                break;
            }
        }
            
        }
        

                //Desktop moving action.
        //move = Input.GetAxis("Horizontal");
       //rigidbody.velocity = new Vector2(move * speed, rigidbody.velocity.y);


                // Scale aciton
       // if (move > 0f)
          //  transform.localScale = new Vector2(1f, 1f);  //karakterin baktığı yönü değiştirmesini sağlıyor
        //else if (move < 0f)
           // transform.localScale = new Vector2(-1f, 1f);

                // Jump Action
        //if (Input.GetButtonDown("Jump") && groundcheck)
        //{
          //  rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);
        //}
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetect")
        {
            //transform.position = new Vector3(startrespawn.position.x, startrespawn.position.y, 0);
            Destroy(gameObject);
            Retrymenu.loadRetry();

        }
    
        if(other.tag == "Block")
        {
            if (groundcheck && rigidbody.velocity.y > 0)
            {
               rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);
               Instantiate(JumpParticle, groundcheckpoint.transform.position, JumpParticle.transform.rotation);
            }
        }
        else if (other.tag == "RedBlock")
        {
            if (groundcheck && rigidbody.velocity.y > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed *1.5f);
                Instantiate(JumpParticle, groundcheckpoint.transform.position, JumpParticle.transform.rotation);
            }
        }
        else if (other.tag == "SuperBlock")
        {
            if (groundcheck && rigidbody.velocity.y > 0)
            {                                                                          
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed * 2f);
                Instantiate(JumpParticle, groundcheckpoint.transform.position, JumpParticle.transform.rotation);
            }
        }

      
    }

    void initBlocksAtStart()
    {
        for(int i=0; i<12; i+=3)
        {
            Vector2 bdpos = new Vector3(Random.Range(-4,4), -1 -i);
            Instantiate(blockDefault, bdpos, blockDefault.transform.rotation);
        }
    }

    void spawnObstacles()
    {
        int x = Random.Range(1, 3);
        if(x==2)
        {
            GameObject a = Instantiate(obstacle) as GameObject;
            a.transform.position = new Vector3(13f, Random.Range(transform.position.y - 2f, transform.position.y - 12f), 2);
        }
        else if(x==1)
        {
            GameObject a = Instantiate(leftobstacle) as GameObject;
            a.transform.position = new Vector3(-13f, Random.Range(transform.position.y - 2f, transform.position.y - 12f), 2);
          
        }
        
        
    }
    IEnumerator obstaclespawntimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.5f);
            spawnObstacles();
        }
    }
    void OutOfScreen()
    {
        if(transform.position.x > 13f)
        {
            transform.position = new Vector2(-12,transform.position.y);
        }
        if(transform.position.x < -13f)
        {
            transform.position = new Vector2(12, transform.position.y);
        }
    }
  
    void Accelerate()
    {
       if (jumpspeed < 20f)
        if (-score %20 == 0)
        {
            jumpspeed += 0.2f;
        }
       
    }

    void ChangeBackgroundColor()
    {
        if (-transform.position.y % 10 == 0)
        {
            spriteRenderer.material.color = Color.Lerp(spriteRenderer.material.color, backgroundcolor[3], 5 * Time.deltaTime);
        }
    }
}

