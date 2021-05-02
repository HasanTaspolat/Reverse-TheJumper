using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDynamics : MonoBehaviour
{
    private SpriteRenderer spriterender;
    public GameObject playerMain;
    public Rigidbody2D playerDirection;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        lockToTarget();
    }

    private void lockToTarget()
    {
        Vector3 Target = new Vector3(0, playerMain.transform.position.y, 2);
       
        
            transform.position = Target;
       

    }
}
