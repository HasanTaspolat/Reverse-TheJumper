using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftObstacleMover : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D r2gb;
    public GameObject deathParticle;
    public RetryMenu Retrymenu; 

    // Start is called before the first frame update
    void Start()
    {
        r2gb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        r2gb.velocity = new Vector2(speed *2, 0);
        if (transform.position.x > 13) Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            Instantiate(deathParticle, collision.transform.position, deathParticle.transform.rotation);
            Destroy(collision.gameObject);
          
        }
    }
}
