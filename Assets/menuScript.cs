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

    void onGUI()
    {
        keyEvent = Event.current;
        // called every frame, tags a key press event as the current event

        if(keyEvent.isKey && waitingForKey)
        {
            // if a user presses a key this code block is executed
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        // this will only execute if we're not already waiting for a key
        // so you can't click on three buttons at a time for example
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;
        // allow update text of the button that is clicked on
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            // basically an infinite while loop until user presses a key
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        // stop the coroutine from executing until our user presses a key
        yield return WaitForKey();
    }
}
