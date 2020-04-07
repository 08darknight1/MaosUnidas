using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int Weight, Speed, maxSpeed, jumpForce;

    private bool isMoving = false, grounded;
    
    private Rigidbody playerRGB;   
        
    public string[] collisionObjects = new string[3];
    
    void Start()
    {
        playerRGB = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            isMoving = true;
            var hAxis = Input.GetAxis("Horizontal");
            var forceValue = hAxis * Speed;

            if (playerRGB.velocity.magnitude < maxSpeed)
            {
                playerRGB.AddForce(new Vector3(forceValue, 0f, 0f));
               // playerRGB.velocity = Vector3.ClampMagnitude(playerRGB.velocity, maxSpeed);
            }
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRGB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        for (var x = 0; x < collisionObjects.Length; x++)
        {
            if (other.gameObject.tag == collisionObjects[x])
            {
                grounded = true;
                break;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        for (var x = 0; x < collisionObjects.Length; x++)
        {
            if (other.gameObject.tag == collisionObjects[x])
            {
                grounded = false;
                break;
            }
        } 
    }

    private void OnCollisionStay(Collision other)
    {
        for (var x = 0; x < collisionObjects.Length; x++)
        {
            if (other.gameObject.tag == collisionObjects[x])
            {
                grounded = true;
                break;
            }
        }
    }

    public bool returnGroundedState()
    {
        return grounded;
    }
}
