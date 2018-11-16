using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullScript : MonoBehaviour {
    public Rigidbody rb;
    private GameObject camera;
    private Animator animator;
    private Vector3 currentVelocity = Vector3.zero;
    private float speed=15.0f;
    private float AddSpeed=0.2f;
    bool onClicked = false;
    private bool colliderConveyeryBand = false;
   



    FoodScript FoodScript;


    Vector3 force =new Vector3(0,0,1);
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
      
    }
	
	// Update is called once per frame
	void Update () {
        //transform.GetComponent<Rigidbody>().AddForce(force, ForceMode.Acceleration);
        //transform.GetComponent<Rigidbody>().MovePosition(force);
        //transform.position = Vector3.SmoothDamp(transform.position,  force, ref currentVelocity, 1f);
        if (onClicked)
        {
            //Debug.Log(onClicked);
            animator.SetTrigger("shrink");
        }
        if (!force.Equals(new Vector3(0, 0, 1))){
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), force);





            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
            if (!onClicked)
            {
                //Debug.Log(onClicked);
                animator.SetTrigger("swim");
            }

            speed -= AddSpeed;
            speed = Mathf.Clamp(speed, 0, speed);
            if(speed==0f)
            {
               
                force = new Vector3(0, 0, 1);
                speed = 15.0f;
                camera.SendMessage("PullOver", true);
            }
            

        }
        else if (force == new Vector3(0, 0, 1))
        {
            animator.SetTrigger("swim");
        }
      
    }


    
    
    //按住时水母头指向
    public void rotate(Vector3 updd)
    {
        
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1), updd);

    }
   

    public void pull(Vector3 force1)
    {
        if (!colliderConveyeryBand)
        {
            force = force1;
        }
        else
        {
            force = force1 / 1.5F;
            speed = 10.0f;
        }
       
        //Debug.Log(force.magnitude);
        //初始速度跟力也有关，之后改
        AddSpeed =2/force.magnitude; 
       
    }
    void OnGUI()
    {
        //GameObject fish = GameObject.FindGameObjectWithTag("Fish");
        if (Event.current != null && Event.current.type == EventType.mouseDown)
        {
            //from = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            onClicked = true;

            //Debug.Log("EventType.mouseDown response");
        }
        else if (Event.current != null && Event.current.type == EventType.mouseUp)
        {
            //fish.SendMessage("pull", fishto - fishfrom);
            onClicked = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.collider.tag == "Food")
        {
            FoodScript = collision.gameObject.GetComponent<FoodScript>();
            FoodScript.SendMessage("eat");
        }


        if (collision.collider.tag == "Enemy")
        {
            Destroy(this.gameObject);

        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.collider.tag == "solat")
        {
            colliderConveyeryBand = true;
        }


       
    }




}
