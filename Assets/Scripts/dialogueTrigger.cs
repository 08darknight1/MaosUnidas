using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public String[] newDialogue = new string[3];
    
    private bool CanInitiateDialogue = false;

    private GameObject dialogueC;
    // Start is called before the first frame update
    void Start()
    {
        dialogueC = GameObject.Find("DialogueCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanInitiateDialogue)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var player = GameObject.Find("Player");
                
                dialogueC.GetComponent<dialogueController>().activateDialoguePanel(newDialogue);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanInitiateDialogue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanInitiateDialogue = false;
        }
    }
}
