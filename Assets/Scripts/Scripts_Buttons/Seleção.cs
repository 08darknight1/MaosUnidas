using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Seleção : MonoBehaviour
{
    private AudioSource OnOff;

    private void Start()
    {
        OnOff = GetComponent<AudioSource>();
    }
    public void PlayA()
    {
        OnOff.Play();
    }
}
