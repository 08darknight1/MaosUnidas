using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Play : MonoBehaviour
{
    public void Button_Play()
    {
        Invoke("MudarScene", 2f);
    }
    private void MudarScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Jogo");
    }
    public void Button_Sair()
    {
        Invoke("Sair",2f);
    }
    private void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }
}
