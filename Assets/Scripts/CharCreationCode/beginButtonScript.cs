using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class beginButtonScript : MonoBehaviour
{
    private GameObject nome, cabelo, roupa;
    
    private Material material1, material2, material3;

    private GameObject canvasGO;

    void Start()
    {
        canvasGO = GameObject.Find("Canvas");
        
        nome = GameObject.Find("InputField").transform.GetChild(1).gameObject;    
    }

    // Update is called once per frame
    void Update()
    {
        if (nome.GetComponent<Text>().text.Length > 1)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void UpdatePlayerData()
    {
        playerData.playerName = nome.GetComponent<Text>().text;

        playerData.hairType = canvasGO.GetComponent<charEditor>().SelectedObjects[0].name;

        playerData.hairMaterial = canvasGO.GetComponent<charEditor>().SelectedMaterials[0].name;

        playerData.clothesType = canvasGO.GetComponent<charEditor>().SelectedObjects[1].name;
        
        playerData.clothesMaterial = canvasGO.GetComponent<charEditor>().SelectedMaterials[1].name;
        
        playerData.clothesDetail = canvasGO.GetComponent<charEditor>().SelectedMaterials[2].name;

        playerData.pantsType = canvasGO.GetComponent<charEditor>().SelectedObjects[2].name;
        
        playerData.pantsMaterial = canvasGO.GetComponent<charEditor>().SelectedMaterials[3].name;
        
        playerData.naked = false;

        playerData.peopleSaved = 0;
        
        playerData.saveIndex = UnityEngine.Random.Range(0, 99999999999);

        playerData.playerPos[0] = 0;
        
        playerData.playerPos[1] = 0;
        
        playerData.playerPos[2] = 0;

        playerData.lastPlaceSaved = null;
        
        SceneManager.LoadScene(2);
    }
}
