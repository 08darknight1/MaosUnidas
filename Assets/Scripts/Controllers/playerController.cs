using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject dialoguePanel; 
    
    public int Weight, Speed, maxSpeed, jumpForce;

    private bool isMoving = false, grounded;
    
    private Rigidbody playerRGB;   
        
    public string[] collisionObjects = new string[3];

    private bool canMove = true;

    public float lowFallMultiplier = 2f, fallMultiplier = 2.5f;

    private GameObject pauseCanvas;
    
    void Start()
    {
        playerRGB = gameObject.GetComponent<Rigidbody>();
        
        var fullCanvas = GameObject.Find("Canvas");

        pauseCanvas = fullCanvas.transform.GetChild(0).gameObject;
        
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if (dialoguePanel.active)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
        
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseCanvas.active == false)
            {
                canMove = false;
                pauseCanvas.SetActive(true);
            }
            else
            {
                canMove = true;
                pauseCanvas.SetActive(false);
            }
        }
        
        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                isMoving = true;
                var hAxis = Input.GetAxis("Horizontal");
                var forceValue = hAxis * Speed;

                if (playerRGB.velocity.magnitude < maxSpeed)
                {
                    playerRGB.AddForce(new Vector3(forceValue, 0f, 0f));
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
            
            if (playerRGB.velocity.y < 0)
            {
                playerRGB.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            } else if (playerRGB.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space)){
                playerRGB.velocity += Vector3.up * Physics.gravity.y * (lowFallMultiplier - 1) * Time.deltaTime;
            }
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

    public void ChangeMoveBool_False()
    {
        canMove = false;
    }
    
    public void ChangeMoveBool_True()
    {
        canMove = true;
    }
}
