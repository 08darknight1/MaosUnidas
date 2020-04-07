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
        var resultPos = playerGO.transform.position.x - gameObject.transform.position.x;
         
        if (resultPos >= 0.8 || resultPos <= -0.8)
        {
            var playerPos = new Vector3(playerGO.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, playerPos, 0.01f);
        }
    }
}
