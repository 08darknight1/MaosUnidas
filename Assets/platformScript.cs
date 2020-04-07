using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    public int objInteractionIndex;
    
    public int maxValue; 

    public int actualValuePublic;

    private int actualValue;

    private GameObject objInteraction;

    private Animator objInteractionAnimator;

    private int oldAddValue = 0;
    
    void Start()
    {
        var parent = gameObject.transform.parent;
        objInteraction = parent.GetChild(objInteractionIndex).gameObject;
        objInteractionAnimator = objInteraction.GetComponent<Animator>();
    }
    
    void Update()
    {
        actualValuePublic = actualValue;
        
        if (actualValue < 0)
        {
            actualValue = 0;
        }

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
        switch (other.tag)
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
        switch (other.tag)
        {
            case "Box":
                actualValue = actualValue - other.GetComponent<boxScript>().Weight;
            break;

            case "Player":
                actualValue = actualValue - other.GetComponent<playerController>().Weight;
            break;
        
            case "npc_Child":
                var parent = other.transform.parent;
                actualValue = actualValue - parent.GetComponent<NPC_script>().Weight;
            break;
        }
    }
}
