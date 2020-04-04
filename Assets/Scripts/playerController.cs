using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int Speed;

    public int maxSpeed;

    private bool isMoving = false;
    
    private Rigidbody playerRGB;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRGB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRGB.velocity.magnitude > maxSpeed){
            playerRGB.velocity = Vector3.ClampMagnitude(playerRGB.velocity, maxSpeed);
        }
        
        if (Input.GetAxisRaw("Horizontal") != 0)
        {   
            isMoving = true;
            var hAxis = Input.GetAxis("Horizontal");
            var forceValue = hAxis * Speed;
            playerRGB.AddForce(new Vector3(forceValue, gameObject.transform.position.y,gameObject.transform.position.z));
        }
        else
        {
            isMoving = false;
        }
        
    }
}
