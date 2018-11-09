using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMangerScript : MonoBehaviour {
    private Vector3 currentVelocity = Vector3.zero;
    private bool finish=false;
    // Use this for initialization
    void Start () {

        //Handles.DrawLine(from, to);
    }
	
	// Update is called once per frame
	void Update () {
        //GameObject fish = GameObject.FindGameObjectWithTag("Fish");
        //Vector3 cameraset = new Vector3(fish.transform.position.x, fish.transform.position.y, -10f);
        //if(cameraset!= transform.position&&finish)
        //{
        //    transform.position = Vector3.SmoothDamp(transform.position, cameraset, ref currentVelocity, 1f);
        //    if(cameraset == transform.position)
        //    {
        //        finish = false;
        //    }
           
        //}
        

    }
    public void PullOver(bool recevice)
    {
        finish = recevice;
    }



}
