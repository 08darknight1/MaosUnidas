using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

[Serializable]
public class playerSaveFile
{
    public string playerName;
       
    public string hairType;
    
    public string hairMaterial;
    
    public string clothesType;
    
    public string clothesMaterial;

    public string clothesDetail;

    public string pantsType;

    public string pantsMaterial;

    public int peopleSaved;

    public float playTime;

    public string mapName;

    public float saveIndex;
    
    public float[] playerPos = new float[3];

    public string lastPlaceSaved;

    public playerSaveFile()
    {
        playerName = playerData.playerName;
       
        hairType = playerData.hairType;
     
        hairMaterial = playerData.hairMaterial;
    
        clothesType = playerData.clothesType;
    
        clothesMaterial = playerData.clothesMaterial;

        clothesDetail = playerData.clothesDetail;

        pantsType = playerData.pantsType;

        pantsMaterial = playerData.pantsMaterial;
       
        peopleSaved = playerData.peopleSaved;
        
        saveIndex = playerData.saveIndex;

        mapName = playerData.mapName;

        playerPos[0] = playerData.playerPos[0];
        playerPos[1] = playerData.playerPos[1];
        playerPos[2] = playerData.playerPos[2];

        lastPlaceSaved = playerData.lastPlaceSaved;
    }
}
