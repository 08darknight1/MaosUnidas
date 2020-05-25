using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseController : MonoBehaviour
{
    private GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        panel = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.active)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }

    public void ReturnToGame()
    {
        panel.SetActive(false);
        var player = GameObject.Find("Player");
        player.GetComponent<playerController>().ChangeMoveBool_True();
    }

    public void ReturnToMenu()
    {
        var clock = GameObject.Find("PlayTimeClock");
        clock.GetComponent<playTimeClock>().DestroyClock();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
