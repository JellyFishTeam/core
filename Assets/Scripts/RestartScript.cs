using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        GameMangerScript gameManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMangerScript>();
        gameManger.SendMessage("restartgame");
        SceneManager.LoadScene("TeachDemo");
       
    }
    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        //button.SetActive(true);
    }

}
