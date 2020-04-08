using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    public GameObject Area;
    public GameObject Luz;

    private void Start()
    {
        Luz.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButton("E"))
            {
                Luz.SetActive(true);
            }
        }
    }
}
