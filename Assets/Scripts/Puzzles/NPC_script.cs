using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class NPC_script : MonoBehaviour
{
    public int Weight;

    private bool withPlayer = false, onCollider = false;

    private GameObject playerObject;
    
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {   
        if (withPlayer)
        {
            var positionDif = playerObject.transform.position.x - gameObject.transform.position.x;

            if (positionDif >= 3.5 || positionDif <= -3.5)
            {
                Vector3 dirFromAtoB = (gameObject.transform.position - playerObject.transform.position).normalized;
                
                float dotProd = Vector3.Dot(dirFromAtoB, playerObject.transform.forward);

                if (dotProd <= -1)
                {
                    transform.LookAt(playerObject.transform);
                }
                
                var newPlayerTransf = new Vector3(playerObject.transform.position.x, 0f, 0f);
                
                transform.position = Vector3.MoveTowards(transform.position, newPlayerTransf, 0.15f);
            }
        }
        
        if (onCollider)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (withPlayer)
                {
                    withPlayer = false;
                    Debug.Log(withPlayer);
                }
                else
                {
                    withPlayer = true;
                    Debug.Log(withPlayer);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onCollider = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onCollider = false;
        }
    }
}
