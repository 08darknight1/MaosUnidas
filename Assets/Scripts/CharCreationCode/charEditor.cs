using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charEditor : MonoBehaviour
{
    public GameObject[] hairTypes = new GameObject[3];
    
    public GameObject[] bodyTypes = new GameObject[3];
    
    public GameObject[] pantsType = new GameObject[3];
    
    public Material[] colorTypes = new Material[3];
    

    private GameObject PantsType, HeadType, ClothesType;
    
    public GameObject[] SelectedObjects = new GameObject[3];

    private GameObject[] trueSelectedObjects = new GameObject[3];

    public Material[] SelectedMaterials = new Material[4];
    
    void Start()
    {       
        HeadType = GameObject.Find("Head");

        ClothesType = GameObject.Find("Body");
        
        PantsType = GameObject.Find("Legs");

        for (int x = 0; x < bodyTypes.Length; x++)
        {
            if (HeadType.transform.GetChild(x).gameObject.active == true)
            {
                SelectedObjects[0] = HeadType.transform.GetChild(x).gameObject;
                SelectedMaterials[0] = HeadType.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>().material;
            }
            if (ClothesType.transform.GetChild(x).gameObject.active == true)
            {
                SelectedObjects[1] = ClothesType.transform.GetChild(x).gameObject;
                SelectedMaterials[1] = ClothesType.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>().material;
                
                var detail = SelectedObjects[1].transform.GetChild(0);
                SelectedMaterials[2] = detail.GetComponent<MeshRenderer>().material;
            }
            if (PantsType.transform.GetChild(x).gameObject.active == true)
            {
                SelectedObjects[2] = PantsType.transform.GetChild(x).gameObject;
                SelectedMaterials[3] = PantsType.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>().material;
            }
        }
        
        for (int x = 0; x < 3; x++)
        {
            trueSelectedObjects[x] = SelectedObjects[x];
        }     
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < 3; x++)
        {
            SelectedObjects[x] = trueSelectedObjects[x];
        }     
    }

    public void changeToNextOption(GameObject go)
    {
        if (go.transform.parent.name == "HairType")
        {
            switch (trueSelectedObjects[0].name)
            {
                case "Type1":
                    trueSelectedObjects[0].SetActive(false);
                    trueSelectedObjects[0] = hairTypes[1];
                    trueSelectedObjects[0].SetActive(true);
                    break;
                case "Type2":
                    trueSelectedObjects[0].SetActive(false);
                    trueSelectedObjects[0] = hairTypes[2];
                    trueSelectedObjects[0].SetActive(true);
                    break;
                case "Type3":
                    trueSelectedObjects[0].SetActive(false);
                    trueSelectedObjects[0] = hairTypes[0];
                    trueSelectedObjects[0].SetActive(true);
                    break;
            }
        }
        
        if (go.transform.parent.name == "BodyType")
        {
            switch (trueSelectedObjects[1].name)
            {
                case "Type1":
                    trueSelectedObjects[1].SetActive(false);
                    trueSelectedObjects[1] = bodyTypes[1];
                    trueSelectedObjects[1].SetActive(true);
                    break;
                case "Type2":
                    trueSelectedObjects[1].SetActive(false);
                    trueSelectedObjects[1] = bodyTypes[2];
                    trueSelectedObjects[1].SetActive(true);
                    break;
                case "Type3":
                    trueSelectedObjects[1].SetActive(false);
                    trueSelectedObjects[1] = bodyTypes[0];
                    trueSelectedObjects[1].SetActive(true);
                    break;
            }
        }
        
        if (go.transform.parent.name == "PantsType")
        {
            switch (trueSelectedObjects[2].name)
            {
                case "Type1":
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2] = pantsType[1];
                    trueSelectedObjects[2].SetActive(true);
                    break;
                case "Type2":
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2] = pantsType[2];
                    trueSelectedObjects[2].SetActive(true);
                    break;
                case "Type3":
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2] = pantsType[0];
                    trueSelectedObjects[2].SetActive(true);
                    break;
            }
        }
        
        UpdateSelectedOM();
    }

    public void changeToLastOption(GameObject go)
    {
        if (go.transform.parent.name == "HairType")
        {
            switch (trueSelectedObjects[0].name)
            {
                case "Type1":
                    trueSelectedObjects[0].SetActive(false);
                    trueSelectedObjects[0] = hairTypes[2];
                    trueSelectedObjects[0].SetActive(true);
                    break;
                case "Type2":
                    trueSelectedObjects[0].SetActive(false);
                    trueSelectedObjects[0] = hairTypes[0];
                    trueSelectedObjects[0].SetActive(true);
                    break;
                case "Type3":
                    trueSelectedObjects[0].SetActive(false);
                    trueSelectedObjects[0] = hairTypes[1];
                    trueSelectedObjects[0].SetActive(true);
                    break;
            }
        }        
                
        if (go.transform.parent.name == "BodyType")
        {
            switch (trueSelectedObjects[1].name)
            {
                case "Type1":
                    trueSelectedObjects[1].SetActive(false);
                    trueSelectedObjects[1] = bodyTypes[2];
                    trueSelectedObjects[1].SetActive(true);
                    break;
                case "Type2":
                    trueSelectedObjects[1].SetActive(false);
                    trueSelectedObjects[1] = bodyTypes[0];
                    trueSelectedObjects[1].SetActive(true);
                    break;
                case "Type3":
                    trueSelectedObjects[1].SetActive(false);
                    trueSelectedObjects[1] = bodyTypes[1];
                    trueSelectedObjects[1].SetActive(true);
                    break;
            }
        }
        
        if (go.transform.parent.name == "PantsType")
        {
            switch (trueSelectedObjects[2].name)
            {
                case "Type1":
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2] = pantsType[2];
                    trueSelectedObjects[2].SetActive(true);
                    break;
                case "Type2":
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2] = pantsType[0];
                    trueSelectedObjects[2].SetActive(true);
                    break;
                case "Type3":
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2].SetActive(false);
                    trueSelectedObjects[2] = pantsType[1];
                    trueSelectedObjects[2].SetActive(true);
                    break;
            }
        }
                
     //   ErrorCheck();
        
        UpdateSelectedOM();
    }    
    
    public void changeToNextColor(GameObject go)
    {
        if (go.transform.parent.name == "HairColor")
        {
            var objMaterial = trueSelectedObjects[0].GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    trueSelectedObjects[0].GetComponent<Renderer>().material = colorTypes[1];
                    break;
                case "RedMaterial (Instance)":
                    trueSelectedObjects[0].GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "YellowMaterial (Instance)":
                    trueSelectedObjects[0].GetComponent<Renderer>().material = colorTypes[0];
                    break;
            }
        }

        if (go.transform.parent.name == "BodyColor")
        {
            var objMaterial = trueSelectedObjects[1].GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    trueSelectedObjects[1].GetComponent<Renderer>().material = colorTypes[1];
                    break;
                case "RedMaterial (Instance)":
                    trueSelectedObjects[1].GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "YellowMaterial (Instance)":
                    trueSelectedObjects[1].GetComponent<Renderer>().material = colorTypes[0];
                    break;
            }
        }
        
        if (go.transform.parent.name == "DetailColor")
        {
            var objChild = SelectedObjects[1].transform.GetChild(0);
            
            var objMaterial = objChild.GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    objChild.GetComponent<Renderer>().material = colorTypes[1];
                    break;
                case "RedMaterial (Instance)":
                    objChild.GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "YellowMaterial (Instance)":
                    objChild.GetComponent<Renderer>().material = colorTypes[0];
                    break;
            }
        }
        
        if (go.transform.parent.name == "PantsColor")
        {
            var objMaterial = trueSelectedObjects[2].GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    trueSelectedObjects[2].GetComponent<Renderer>().material = colorTypes[1];
                    break;
                case "RedMaterial (Instance)":
                    trueSelectedObjects[2].GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "YellowMaterial (Instance)":
                    trueSelectedObjects[2].GetComponent<Renderer>().material = colorTypes[0];
                    break;
            }
        }
        
        UpdateSelectedOM();
    }
    
    public void changeToLastColor(GameObject go)
    {
        if (go.transform.parent.name == "HairColor")
        {
            var objMaterial = SelectedObjects[0].GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    SelectedObjects[0].GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "RedMaterial (Instance)":
                    SelectedObjects[0].GetComponent<Renderer>().material = colorTypes[0];
                    break;
                case "YellowMaterial (Instance)":
                    SelectedObjects[0].GetComponent<Renderer>().material = colorTypes[1];
                    break;
            }
        }

        if (go.transform.parent.name == "BodyColor")
        {
            var objMaterial = SelectedObjects[1].GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    SelectedObjects[1].GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "RedMaterial (Instance)":
                    SelectedObjects[1].GetComponent<Renderer>().material = colorTypes[0];
                    break;
                case "YellowMaterial (Instance)":
                    SelectedObjects[1].GetComponent<Renderer>().material = colorTypes[1];
                    break;
            }
        }
        
        if (go.transform.parent.name == "DetailColor")
        {
            var objChild = SelectedObjects[1].transform.GetChild(0);
            
            var objMaterial = objChild.GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    objChild.GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "RedMaterial (Instance)":
                    objChild.GetComponent<Renderer>().material = colorTypes[0];
                    break;
                case "YellowMaterial (Instance)":
                    objChild.GetComponent<Renderer>().material = colorTypes[1];
                    break;
            }
        }
        
        if (go.transform.parent.name == "PantsColor")
        {
            var objMaterial = trueSelectedObjects[2].GetComponent<Renderer>().material;

            switch (objMaterial.name)
            {
                case "BlueMaterial (Instance)":
                    trueSelectedObjects[2].GetComponent<Renderer>().material = colorTypes[2];
                    break;
                case "RedMaterial (Instance)":
                    trueSelectedObjects[2].GetComponent<Renderer>().material = colorTypes[0];
                    break;
                case "YellowMaterial (Instance)":
                    trueSelectedObjects[2].GetComponent<Renderer>().material = colorTypes[1];
                    break;
            }
        }
        
        UpdateSelectedOM();
    }

    private void UpdateSelectedOM()
    {
        for (int x = 0; x < 3; x++)
        {
            if (HeadType.transform.GetChild(x).gameObject.active == true)
            {
                trueSelectedObjects[0] = HeadType.transform.GetChild(x).gameObject;
                SelectedMaterials[0] = HeadType.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>().material;
            }
            if (ClothesType.transform.GetChild(x).gameObject.active == true)
            {
                trueSelectedObjects[1] = ClothesType.transform.GetChild(x).gameObject;
                SelectedMaterials[1] = ClothesType.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>().material;
                                
                var detail = trueSelectedObjects[1].transform.GetChild(0);
                SelectedMaterials[2] = detail.GetComponent<MeshRenderer>().material;
            }
            if (PantsType.transform.GetChild(x).gameObject.active == true)
            {
                trueSelectedObjects[2] = PantsType.transform.GetChild(x).gameObject;
                SelectedMaterials[3] = PantsType.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>().material;
            }
        }
    }
}
