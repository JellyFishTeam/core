using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour {
    Vector3 target;
    //Vector3 velocity = Vector3.zero;
   
    Vector3 updd;
    int count=0;

    // Use this for initialization
    void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.left * Time.deltaTime * 3.0f);
        
        target = transform.position + Quaternion.Euler(0,0 , Random.value * 90) * Vector3.forward;
        //updd = Quaternion.Euler(0, 0, Random.value * 90) * transform.up;
        if (count > 10)
        {
            updd = Quaternion.Euler(0, 0, Random.Range(-1f,1f)*45) * transform.up;
            
            count = 0;
        }
       
                 
       
        Vector3 direct = target - transform.position;
        
        transform.rotation = Quaternion.LookRotation(direct,updd);
        
        transform.Translate(Vector3.left * Time.deltaTime * 3.0f,Space.Self);

        count++;

        
     
    }
}
