using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleScript : MonoBehaviour
{
    public int objInteractionIndex;
    
    public int maxValue; 

    public int actualValuePublic;

    private int actualValue = 0, truePuzzleType;

    private GameObject objInteraction;

    private Animator objInteractionAnimator;

    private int oldAddValue = 0;

    public int puzzleType;

    public bool PlayingAnimation, IsUP = false;

    private bool playerNeedExit = false, gambosa = false;
    
    void Start()
    {
        var parent = gameObject.transform.parent;
        objInteraction = parent.GetChild(objInteractionIndex).gameObject;
        objInteractionAnimator = objInteraction.GetComponent<Animator>();

        truePuzzleType = puzzleType;
    }
    
    void Update()
    {
        puzzleType = truePuzzleType;
 
        actualValuePublic = actualValue;       

        if (actualValue < 0)
        {
            actualValue = 0;
        }
        
        switch (truePuzzleType)
        {
            case 0:
                if (actualValue >= maxValue)
                {
                    objInteractionAnimator.ResetTrigger("Close");
                    objInteractionAnimator.SetTrigger("Open");
                }
                else
                {
                    objInteractionAnimator.ResetTrigger("Open");
                    objInteractionAnimator.SetTrigger("Close");
                }
            break;
            
            case 1:
                if (actualValue >= maxValue)
                {
                    if (playerNeedExit == false)
                    {
                        objInteractionAnimator.ResetTrigger("DOWN");
                        var timer = gameObject.transform.parent;
                        timer.GetComponent<timerScript>().activateTimer();
                        if (timer.GetComponent<timerScript>().returnGoalValue() == true)
                        {
                            objInteractionAnimator.SetTrigger("UP");
                            var player = GameObject.Find("Player");
                            player.transform.parent = gameObject.transform;
                        }
                    }
                }

                if (PlayingAnimation == true)
                {
                    var player = GameObject.Find("Player");
                    player.GetComponent<playerController>().ChangeMoveBool_False();
                    playerNeedExit = true;
                }
                else
                {
                    var player = GameObject.Find("Player");
                    
                    player.transform.parent = null;
                    
                    player.GetComponent<playerController>().ChangeMoveBool_True();

                    if (IsUP)
                    {
                        truePuzzleType = -1;
                        
                        var timer = gameObject.transform.parent;                  
                        timer.GetComponent<timerScript>().resetTimer();
                    }
                }
            break;
                
            case -1:
                if (actualValue >= maxValue)
                {
                    if (playerNeedExit == false)
                    {
                        objInteractionAnimator.ResetTrigger("UP");
                        var timer = gameObject.transform.parent;
                        timer.GetComponent<timerScript>().activateTimer();
                        if (timer.GetComponent<timerScript>().returnGoalValue() == true)
                        {
                            objInteractionAnimator.SetTrigger("DOWN");
                            var player = GameObject.Find("Player");
                            player.transform.parent = gameObject.transform;
                            player.GetComponent<Rigidbody>().Sleep();
                        }
                    }
                }

                if (PlayingAnimation == true)
                {
                    var player = GameObject.Find("Player");
                    player.GetComponent<playerController>().ChangeMoveBool_False();
                    playerNeedExit = true;
                }
                else
                {
                    var player = GameObject.Find("Player");

                    player.transform.parent = null;
                    
                    player.GetComponent<playerController>().ChangeMoveBool_True();

                    if (gambosa == false)
                    {/*
                        var vetor = new Vector3(player.transform.position.x, player.transform.position.y + 0.1f,
                            player.transform.position.z);
                        player.GetComponent<Rigidbody>().transform.position = vetor;*/
                        player.GetComponent<Rigidbody>().WakeUp();
                        gambosa = true;
                    }

                    if (IsUP == false)
                    {
                        truePuzzleType = 1;
                        
                        var timer = gameObject.transform.parent;                  
                        timer.GetComponent<timerScript>().resetTimer();
                    }
                }
            break;
            
            case 2:
                if (lightCount() >= maxValue)
                {
                    objInteractionAnimator.ResetTrigger("Close");   
                    objInteractionAnimator.SetTrigger("Open");
                }
                else
                {
                    objInteractionAnimator.ResetTrigger("Open");   
                    objInteractionAnimator.SetTrigger("Close");
                }

            break;
        }
    }

    public void addFromSubPlatform(int valueToAdd)
    {
        if (oldAddValue != valueToAdd)
        {
            actualValue = actualValue + valueToAdd;        
            oldAddValue = valueToAdd;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Box":
                actualValue = actualValue + other.GetComponent<boxScript>().Weight;
            break;
            
            case "Player":
                actualValue = actualValue + other.GetComponent<playerController>().Weight;
            break;
            
            case "npc_Child":
                var parent = other.transform.parent;
                actualValue = actualValue + parent.GetComponent<NPC_script>().Weight;
            break;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Box":
                actualValue = actualValue - other.GetComponent<boxScript>().Weight;
            break;

            case "Player":
                actualValue = actualValue - other.GetComponent<playerController>().Weight;
                playerNeedExit = false;
                gambosa = false;
            break;
        
            case "npc_Child":
                var parent = other.transform.parent;
                actualValue = actualValue - parent.GetComponent<NPC_script>().Weight;
            break;
        }
        
        if (playerNeedExit == false)
        {
            var timer = GameObject.Find("ElevatorMechanism");

            if (timer.GetComponent<timerScript>().returnTimerState())
            {
                timer.GetComponent<timerScript>().resetTimer();
            }
        }        
    }

    private int lightCount()
    {
        var cont = 0;
        
        for (int x = 0; x < maxValue; x++)
        {
            var child = gameObject.transform.GetChild(x).gameObject;

            var child2 = child.transform.GetChild(0).gameObject;

            if (child2.GetComponent<Light>().isActiveAndEnabled)
            {
                cont++;
            }
        }

        return cont;
    }
}
