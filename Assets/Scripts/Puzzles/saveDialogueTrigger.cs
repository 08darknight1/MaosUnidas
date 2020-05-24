using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class saveDialogueTrigger : MonoBehaviour
{
    public string[] newDialogue = new string[3];
    
    private bool CanInitiateDialogue = false;

    private GameObject dialogueC;

    private bool alreadyActivated = false;

    public GameObject luzinha;

    void Start()
    {
        dialogueC = GameObject.Find("DialogueCanvas");
    }
    
    void Update()
    {
        if (CanInitiateDialogue)
        {
            if (alreadyActivated == false)
            {
                var player = GameObject.Find("Player");

                dialogueC.GetComponent<dialogueController>().activateDialoguePanel(newDialogue);

                alreadyActivated = true;
/*
                if (saveSystem.CheckIfFileExist())
                {
                    playerData.playTime = Time.deltaTime;
                    saveSystem.SaveOverFile();
                }
                else
                {
                    playerData.playTime = Time.deltaTime;*/

                playerData.lastPlaceSaved = gameObject.name;
                
                playerData.playerPos[0] = player.transform.position.x;
                playerData.playerPos[1] = player.transform.position.y;
                playerData.playerPos[2] = player.transform.position.z;
                
                playerData.mapName = SceneManager.GetActiveScene().name;
                saveSystem.CreateNewSaveFile();
             //   }
             
             luzinha.SetActive(true);
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
            alreadyActivated = false;
        }
    }

    public void changeAlreadyActivated()
    {
        alreadyActivated = true;
    }
}
