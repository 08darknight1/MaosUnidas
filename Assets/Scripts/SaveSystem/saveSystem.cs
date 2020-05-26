using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.XR.WSA;

public static class saveSystem
{
    public static void CreateNewSaveFile()
    {
        playerSaveFile saveFile = new playerSaveFile();

        saveFile.playTime += GameObject.Find("PlayTimeClock").GetComponent<playTimeClock>().timePassed;

        BinaryFormatter formatterr = new BinaryFormatter();

        string namer = saveFile.playerName;

        string allTogether = "/"+namer+".08dk1";
        
        string path = Path.Combine(Application.persistentDataPath + allTogether);
        
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        
        FileInfo[] fileInfo = dir.GetFiles("*.08dk1*");
        
        FileInfo[] fileRepeated = new FileInfo[fileInfo.Length];
                
        var cont = 0;
                
        Debug.Log("ESTE EH O SAVEINDEX DO MELIANTE: "+saveFile.saveIndex);
        for (int x = 0; x < fileInfo.Length; x++)
        {
            if (fileInfo[x].Name.Contains(namer))
            {
                fileRepeated[cont] = fileInfo[x];
                cont++;
            }
        }

        Debug.Log("TEM " +fileRepeated.Length+" FILES COM O MESMO NOME");
        
        var foundSaveFile = false;
        
        if(File.Exists(path))
            {
                for (int x = 0; x < fileRepeated.Length; x++)
                {
                    Debug.Log("PROCURANDO O DESGRAÇADO NO INDEX "+x);
                    
                    if (fileRepeated[x] == null)
                    {
                        Debug.Log("FILE REPEATED DEU NULL ENTAO TO VAZANDO");
                        break;
                    }                   
                    
                    string path2 = Path.Combine(Application.persistentDataPath + "/" + fileRepeated[x].Name);
                                       
                    FileStream streamer2 = new FileStream(path2, FileMode.Open);

                    Debug.Log("O CAMINHO É: " + path2);
                    
                    playerSaveFile oldFile = formatterr.Deserialize(streamer2) as playerSaveFile;

                    var time = oldFile.playTime;
                    var name = oldFile.playerName;
                    var save = oldFile.saveIndex;
                    
                    streamer2.Close();

                    Debug.Log("PROCURADO: " + saveFile.playerName + " / ENCONTRADO: " + name);
                    Debug.Log("PROCURADO: " + saveFile.saveIndex + " / ENCONTRADO: " + save);
                    
                    if (name == saveFile.playerName && save == saveFile.saveIndex)
                    {
                        Debug.Log("ACHEI O DESGRAÇADO E SALVEI BUNITO");
                        saveFile.playTime += time;
                        FileStream streamer5 = new FileStream(path2, FileMode.Create);
                        formatterr.Serialize(streamer5, saveFile);
                        streamer5.Close();
                        foundSaveFile = true;
                        break;
                    }
                    
                    Debug.Log("O DESGRAÇADO NÃO ESTA NO INDEX "+x);
                }

                if(foundSaveFile == false)
                {
                    Debug.Log("NÃO ACHEI O DESGRAÇADO, TO CRIANDO UM SAVE NOVO");
                    
                    FileStream streamer2 = new FileStream(path, FileMode.Open);
                    
                    DirectoryInfo dir2 = new DirectoryInfo(Application.persistentDataPath);

                    FileInfo[] fileInf2 = dir2.GetFiles("*.08dk1*");

                    var shitToAdd = 0;

                    for (int x = 0; x < fileInf2.Length; x++)
                    {
                        if (fileInf2[x].Name.Contains(namer))
                        {
                            shitToAdd++;
                        }
                    }

                    var shitInString = shitToAdd.ToString();

                    var changedName = "/" + namer + shitInString + ".08dk1";

                    path = Path.Combine(Application.persistentDataPath + changedName);

                    streamer2 = new FileStream(path, FileMode.CreateNew);
                    formatterr.Serialize(streamer2, saveFile);
                    streamer2.Close();
                }
            }
            else
            {
                FileStream streamer = new FileStream(path, FileMode.Create);

                formatterr.Serialize(streamer, saveFile);
                streamer.Close();
            }
        
    }

    public static playerSaveFile[] LoadFile()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        
        FileInfo[] fileInfo = dir.GetFiles("*.08dk1*");
        
        playerSaveFile[] saveFiles = new playerSaveFile[fileInfo.Length];

        for (int x = 0; x < saveFiles.Length; x++)
        {
            Debug.Log(fileInfo[x].Name);
        }
        
        for (int x = 0; x < saveFiles.Length; x++)
        {
            string path = Path.Combine(Application.persistentDataPath + "/" +fileInfo[x].Name);
            
            if (File.Exists(path))
            {
                BinaryFormatter formatterr = new BinaryFormatter();
                FileStream streamer = new FileStream(path, FileMode.Open);
            
                playerSaveFile saveFile = formatterr.Deserialize(streamer) as playerSaveFile;

                saveFiles[x] = saveFile;      
                
                streamer.Close();
            }   
        }     
        
        return saveFiles;
    }

    public static bool returnAllFilesState()
    {
        BinaryFormatter formatterr = new BinaryFormatter();
        
        var occupied = false;
        
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        
        FileInfo[] fileInfo = dir.GetFiles("*.08dk1*");
        
        FileInfo[] fileReapeated = new FileInfo[fileInfo.Length];

        var fileIndex = 0;

        var playerDataName = playerData.playerName;
        
        var playerDataSaveIndex = playerData.saveIndex;

        if (fileInfo.Length >= 5)
        {
            occupied = true;
        }

        for (int x = 0; x < fileInfo.Length; x++)
        {
            if (fileInfo[x].Name.Contains(playerDataName))
            {
                fileReapeated[fileIndex] = fileInfo[x];
                fileIndex++;
            }
        }

        for (int x = 0; x < fileReapeated.Length; x++)
        {
            if (fileReapeated[x] == null)
            {
                break;
            }
            else
            {
                Debug.Log("FILE REPEATED N EH NULL");
                
                string path3 = fileInfo[x].Directory + "/" + fileInfo[x].Name;
                
                FileStream streamer3 = new FileStream(path3, FileMode.Open);                
                                
                if (File.Exists(path3))
                {
                    Debug.Log("A FILE EXISTE NO PATH DELA");
                    playerSaveFile saveFile = formatterr.Deserialize(streamer3) as playerSaveFile;

                    var saveFilePlayerName = saveFile.playerName;
                    var saveFileSaveIndex = saveFile.saveIndex;
                    
                    formatterr.Serialize(streamer3, saveFile);
                    streamer3.Close();

                    if (saveFilePlayerName == playerDataName && saveFileSaveIndex == playerDataSaveIndex)
                    {
                        Debug.Log("TEM UMA SAVE FILE COM O NOME E O SAVE INDEX DESSE CARA");
                        occupied = false;
                        break;
                    }
                } 
            }           
        }
        
        return occupied;
    }
}
