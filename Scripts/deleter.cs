using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleter : MonoBehaviour
{
    public GameObject player1;
    public GameObject blockDefault;
    public GameObject redblockDefault;
    public GameObject superblock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - 15f > player1.transform.position.y)
        {
            transform.position = new Vector3(0, transform.position.y - 5.5f, 0f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Block" || other.tag == "RedBlock" || other.tag == "SuperBlock")
        {
            Destroy(other.gameObject);
            Vector3 newblockpos = new Vector3(Random.Range(-9f, 9f), player1.transform.position.y - 5.4f, 0);
            int num = Random.Range(1, 18);
            if (num > 3 )
            {
              
                Instantiate(blockDefault, newblockpos, blockDefault.transform.rotation);
            
            }
            else if(num == 2 || num == 3)
            {
           
                Instantiate(redblockDefault, newblockpos, blockDefault.transform.rotation);
              
            }
            else if(num==1)
            {
                Instantiate(superblock, newblockpos, blockDefault.transform.rotation);
            }
        }

        if(other.tag == "Particle")
        {
            Destroy(other.gameObject);
        }
     
    }

}
