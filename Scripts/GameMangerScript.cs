using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameMangerScript : MonoBehaviour {
    private bool onClicked = false;
    Vector3 from;
    Vector3 to;
    Vector3 fishfrom;
    Vector3 fishto;
    public LineRenderer[] Lines;
  
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
     void Update () {
        GameObject fish = GameObject.FindGameObjectWithTag("Fish");
        fishfrom = fish.transform.position;
        fishto = fish.transform.position;
        if (onClicked)
        {
            to = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            fishto = fish.transform.position +from - to;
            //Debug.Log(fishto);
        }
        else if (!onClicked)
        {
            
            from = new Vector3(0, 0, 0);
            to = new Vector3(0, 0, 0);
            fishto = fish.transform.position;
            
        }

        Lines[0].SetPosition(0, from);
        Lines[0].SetPosition(1, to);
        Lines[1].SetPosition(0, fishfrom);
        Lines[1].SetPosition(1, fishto);
        if(fishto-fishfrom != new Vector3(0f, 0f, 0f))
        {
            fish.SendMessage("rotate", fishto - fishfrom);
        }
       
        



    }


    private void OnMouseDown()
    {
       
    }

    private void OnMouseUp()
    {
       
    }

    void OnGUI()
    {
        GameObject fish = GameObject.FindGameObjectWithTag("Fish");
        if (Event.current != null && Event.current.type == EventType.mouseDown)
        {        
            from = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            onClicked = true;
                
            //Debug.Log("EventType.mouseDown response");
        }
        else if(Event.current != null && Event.current.type == EventType.mouseUp)
        {
            fish.SendMessage("pull", fishto - fishfrom);
            onClicked = false;
        }
       
    }


}
