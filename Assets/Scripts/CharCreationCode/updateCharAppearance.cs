using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateCharAppearance : MonoBehaviour
{
    private GameObject head, body, legs, defHead, defBody, defLegs;

    public Material[] AllPlayerMaterials = new Material[3];
    
    void Start()
    {
        head = gameObject.transform.GetChild(0).gameObject;
        
        body = gameObject.transform.GetChild(1).gameObject;

        legs = gameObject.transform.GetChild(2).gameObject;
        
        for (int x = 0; x < 3; x++)
        {
            defHead = getRightChildren(defHead, head, x, 0);
            
            defBody = getRightChildren(defBody, body, x, 1);
            
            defLegs = getRightChildren(defLegs, legs, x, 2);
        }

        if (playerData.naked == false)
        {
            var detailGO = defBody.transform.GetChild(0).gameObject;

            getRightColors(defHead.gameObject, 0);

            getRightColors(defBody.gameObject, 1);

            getRightColors(detailGO.gameObject, 2);

            getRightColors(defLegs.gameObject, 3);
        }
        else
        {
            playerData.playerName = "Player";
        }
    }
    
    private void getRightColors(GameObject toChange, int index)
    {
        for (int x = 0; x < AllPlayerMaterials.Length; x++)
        {
            var allFirstOnes = AllPlayerMaterials[x].name.Substring(0, 3);
            
            var hairColor = playerData.hairMaterial.Substring(0, 3);
  
            var clothesColor = playerData.clothesMaterial.Substring(0, 3);
            
            var detailColor = playerData.clothesDetail.Substring(0, 3);
            
            var pantsColor = playerData.pantsMaterial.Substring(0, 3);
            
            switch (index)
            {
                case 0:
                    if (hairColor == allFirstOnes)
                    {
                        toChange.GetComponent<MeshRenderer>().material = AllPlayerMaterials[x];
                    }
                break;
                case 1:
                    if (clothesColor == allFirstOnes)
                    {
                        toChange.GetComponent<MeshRenderer>().material = AllPlayerMaterials[x];
                    }
                break;
                case 2:
                    if (detailColor == allFirstOnes)
                    {
                        toChange.GetComponent<MeshRenderer>().material = AllPlayerMaterials[x];
                    }
                break;
                case 3:
                    if (pantsColor == allFirstOnes)
                    {
                        toChange.GetComponent<MeshRenderer>().material = AllPlayerMaterials[x];
                    }
                break;
            }
        }
    }

    private GameObject getRightChildren(GameObject child, GameObject parent, int index, int type)
    {
        var go = child;
        
        var stringzona = " ";
        
        switch (type)
        {
            case 0:
                stringzona = playerData.hairType;
            break;
            case 1:
                stringzona = playerData.clothesType;
            break;
            case 2:
                stringzona = playerData.pantsType;
            break;
        }
        
        child = parent.transform.GetChild(index).gameObject;
            
        if (child.name != stringzona)
        {
            Destroy(child.gameObject);
        }
        else
        {
            go = child.gameObject;
        }
        
        return go;
    }
}
