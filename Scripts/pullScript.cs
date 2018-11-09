using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullScript : MonoBehaviour {
    public Rigidbody rb;
    private GameObject camera;
    private Vector3 currentVelocity = Vector3.zero;
    private float speed=15.0f;
    private float AddSpeed=0.2f;
    
    Vector3 force =new Vector3(0,0,1);
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
        //transform.GetComponent<Rigidbody>().AddForce(force, ForceMode.Acceleration);
        //transform.GetComponent<Rigidbody>().MovePosition(force);
        //transform.position = Vector3.SmoothDamp(transform.position,  force, ref currentVelocity, 1f);
        if(!force.Equals(new Vector3(0, 0, 1))){
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), force);
            
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
           
            speed -= AddSpeed;
            speed = Mathf.Clamp(speed, 0, speed);
            if(speed==0f)
            {
               
                force = new Vector3(0, 0, 1);
                speed = 15.0f;
                camera.SendMessage("PullOver", true);
            }

        }
      
    }
    
    

    public void rotate(Vector3 updd)
    {
        
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1), updd);

    }
   

    public void pull(Vector3 force1)
    {
        force = force1;
        //Debug.Log(force.magnitude);
        //初始速度跟力也有关，之后改
        AddSpeed =2/force.magnitude; 
       
    }


   
}
