using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPosition : MonoBehaviour
{
    public GameObject player1;
    public GameObject blockDefault;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - 20f > player1.transform.position.y)
        {
            transform.position = new Vector3(0f, transform.position.y - 4f, 0f);
        }
    }


   /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FallDetect")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Vector2 newblockpos = new Vector2(Random.Range(-4, 4), player1.transform.position.y - 18);
            Instantiate(blockDefault, newblockpos, blockDefault.transform.rotation);

        }
    }
    */

}
