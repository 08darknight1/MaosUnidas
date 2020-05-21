using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Play : MonoBehaviour
{
    private AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Button_Play()
    {
        audio.Play();
        Invoke("MudarScene", 2f);
    }
    private void MudarScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharCreatorTest");
    }
    public void Button_Sair()
    {
        audio.Play();
        Invoke("Sair",2f);
    }
    private void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }
}
