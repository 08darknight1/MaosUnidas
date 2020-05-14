using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subPlatformScript : MonoBehaviour
{
    private GameObject mainPlatform;

    private int actualValue;

    private int valueSent = 0;
    
    void Start()
    {
        var parent = gameObject.transform.parent;
        mainPlatform = parent.GetChild(0).gameObject;
    }
    
    void Update()
    {
        if (actualValue > actualValue)
        {
            mainPlatform.GetComponent<puzzleScript>().addFromSubPlatform(actualValue);
        }
        else
        {
            var praMandar = actualValue - valueSent;
            mainPlatform.GetComponent<puzzleScript>().addFromSubPlatform(praMandar);
        }

        valueSent = actualValue;
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
