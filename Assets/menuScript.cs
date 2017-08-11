using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;

	// Use this for initialization
	void Start () {
        menuPanel = transform.Find("Panel");
        menuPanel.gameObject.SetActive(false);
        waitingForKey = false;

        // iterate through each child within the menu object
        // updating the text the of child button object to equal the keyCode

        for (int i = 0; i < menuPanel.childCount; i++)
        {
            if (menuPanel.GetChild(i).name == "forwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManagerScript.GM.forward.ToString();
            else if (menuPanel.GetChild(i).name == "backwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManagerScript.GM.backward.ToString();
            else if (menuPanel.GetChild(i).name == "leftKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManagerScript.GM.left.ToString();
            else if (menuPanel.GetChild(i).name == "rightKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManagerScript.GM.right.ToString();
            else if (menuPanel.GetChild(i).name == "jumpKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManagerScript.GM.jump.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf) 
            menuPanel.gameObject.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(false);
    }
}
