using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadSystemMenu : MonoBehaviour
{
    public GameObject[] saveButtons;

    public GameObject noSavesText;

    private playerSaveFile[] saveFiles;
    
    private void Start()
    {
      saveFiles = saveSystem.LoadFile();

  //    Debug.Log(saveFiles.Length);
      
      if (saveFiles.Length > 0)
      {   
          for (int x = 0; x < saveButtons.Length; x++)
          {
              saveButtons[x].SetActive(false);
          }

          for (int x = 0; x < saveFiles.Length; x++)
          {
              if (saveFiles[x] != null)
              {
                  saveButtons[x].SetActive(true);
                  createButtonForAllFiles(saveButtons[x], saveFiles[x]);
              }
          }
      }
      else
      {
          noSavesText.SetActive(true);
          
          for (int x = 0; x < saveButtons.Length; x++)
          {
              saveButtons[x].SetActive(false);
          }
      }
    }

    private void LateUpdate()
    {
        for (int x = 0; x < saveButtons.Length; x++)
        {
            if (saveButtons[x].active == true)
            {
                var playtime = saveButtons[x].transform.GetChild(6);
                playtime.GetComponent<Text>().text = saveFiles[x].playTime.ToString("F2");
            }
        }
    }

    private void createButtonForAllFiles(GameObject button, playerSaveFile saveFile)
    {
        var nome = button.transform.GetChild(0);
        var peopleSaved = button.transform.GetChild(2);
        var map = button.transform.GetChild(4);
        var playtime = button.transform.GetChild(6);
        
                    
        nome.GetComponent<Text>().text = saveFile.playerName;
        peopleSaved.GetComponent<Text>().text = saveFile.peopleSaved.ToString();
        map.GetComponent<Text>().text = saveFile.mapName;
        
        playtime.GetComponent<Text>().text = saveFile.playTime.ToString("F2");

        nome.GetComponent<Text>().text = saveFile.playerName;
        peopleSaved.GetComponent<Text>().text = saveFile.peopleSaved.ToString();
        map.GetComponent<Text>().text = saveFile.mapName;
        playtime.GetComponent<Text>().text = saveFile.playTime.ToString();
    }

    public void loadGame(GameObject button)
    {
        var index = 0;

        for (int x = 0; x < saveButtons.Length; x++)
        {
            if (button == saveButtons[x])
            {
                index = x;
                break;
            }
        }
        
        playerData.playerName = saveFiles[index].playerName;
        
        playerData.hairType = saveFiles[index].hairType;
        playerData.hairMaterial = saveFiles[index].hairMaterial;
        
        playerData.clothesType = saveFiles[index].clothesType;
        playerData.clothesMaterial = saveFiles[index].clothesMaterial;
        playerData.clothesDetail = saveFiles[index].clothesDetail;
        
        playerData.pantsType = saveFiles[index].pantsType;
        playerData.pantsMaterial = saveFiles[index].pantsMaterial;
        
        playerData.peopleSaved = saveFiles[index].peopleSaved;
        
        playerData.mapName = saveFiles[index].mapName;
        
        playerData.playerPos[0] = saveFiles[index].playerPos[0];
        playerData.playerPos[1] = saveFiles[index].playerPos[1];
        playerData.playerPos[2] = saveFiles[index].playerPos[2];
        
        playerData.saveIndex = saveFiles[index].saveIndex;
        
        playerData.naked = false;

        playerData.lastPlaceSaved = saveFiles[index].lastPlaceSaved;
        
        SceneManager.LoadScene(playerData.mapName);
    }
}
