using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour {
    Vector3 target;
    //Vector3 velocity = Vector3.zero;
    private float z=1;
    Vector3 updd;
    int count=0;

    // Use this for initialization
    void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.left * Time.deltaTime * 3.0f);

        //target = transform.position + Quaternion.Euler(0,0 , Random.value * 90) * Vector3.forward;
        //updd = Quaternion.Euler(0, 0, Random.value * 90) * transform.up;
        if (transform.position.x > 40f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1), new Vector3(0, 1, 0));
            z = -1;
        }
        if (transform.position.x < 0f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            z = 1;
        }
        if (transform.position.y > 10)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, -1, 0));
        }
        if (transform.position.y < -10)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
        }
        if (transform.position.y > 10f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, -1, 0));
            
        }
        if (transform.position.y < -10f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
        }
        if (count > 10)
        {
            updd = Quaternion.Euler(0, 0, Random.Range(-1f,1f)*10) * transform.up;
            
            count = 0;
        }
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, z), updd);
       
                 
       
       // Vector3 direct = target - transform.position;
        
        
        
        transform.Translate(Vector3.right * Time.deltaTime * 3.0f,Space.Self);

        count++;

        
     
    }
}
