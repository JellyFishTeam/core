using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {
    private GameMangerScript gameMangerScript;
	// Use this for initialization
	void Start () {
        gameMangerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMangerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void eat()
    {
        gameMangerScript.SendMessage("getfood");
        Destroy(this.gameObject);
    }
}
