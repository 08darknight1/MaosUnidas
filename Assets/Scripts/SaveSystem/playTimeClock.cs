using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playTimeClock : MonoBehaviour
{
    public float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 1 && SceneManager.GetActiveScene().name == "TelaInicial")
        {
            Time.timeScale = 1;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            timePassed += Time.deltaTime;
        }
    }

    public void DestroyClock()
    {
        Destroy(gameObject);
    }
}
