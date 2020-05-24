using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{   
    private GameObject playerGO;
    
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var resultPosX = playerGO.transform.position.x - gameObject.transform.position.x;
         
        if (resultPosX >= 0.8 || resultPosX <= -0.8)
        {
            var playerPos = new Vector3(playerGO.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, playerPos, 0.02f);
        }
        
        var resultPosY = playerGO.transform.position.y - gameObject.transform.position.y;
        /*
        if (resultPosY >= 3 || resultPosY <= 0)
        {*/
            var playerPosY = new Vector3(gameObject.transform.position.x, playerGO.transform.position.y + 3, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, playerPosY, 0.05f);
        //}
    }
}
