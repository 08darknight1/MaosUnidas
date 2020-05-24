using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
  //  public GameObject Area;
    public GameObject Luz;

    private void Start()
    {
        Luz.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("E"))
            {
                if (Luz.active == true)
                {
                    Luz.SetActive(false);
                }
                else
                {
                    Luz.SetActive(true);
                }
            }
        }
    }
}
