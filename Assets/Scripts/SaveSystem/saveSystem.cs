using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem
{
    public static void CreateNewSaveFile()
    {        
        playerSaveFile saveFile = new playerSaveFile();

        BinaryFormatter formatterr = new BinaryFormatter();
        
     //   string path = Path.Combine(Application.persistentDataPath + "/player.08dk1");

        string namer = saveFile.playerName;

        string allTogether = "/"+namer+".08dk1";
        
        string path = Path.Combine(Application.persistentDataPath + allTogether);
        
        //boContainer.Save(Path.Combine(Application.persistentDataPath, "objects.xml"));*/
        FileStream streamer = new FileStream(path, FileMode.Create);
        
        saveFile.playTime += GameObject.Find("PlayTimeClock").GetComponent<playTimeClock>().timePassed;
        
        formatterr.Serialize(streamer, saveFile);
        streamer.Close();
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
            }   
        }
       
        return saveFiles;
    }
/*
    public static void SaveOverFile()
    {
        BinaryFormatter formatterr = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath);
        FileStream streamer = new FileStream(path, FileMode.Create);
        
        var pathDir = new DirectoryInfo(path);

        var dirFiles = pathDir.GetFiles();

        playerSaveFile[] SaveFilesArray = new playerSaveFile[dirFiles.Length];
        
        if (dirFiles[0] != null)
        {
            for (int x = 0;x < dirFiles.Length; x++)
            {
                SaveFilesArray[x] = formatterr.Deserialize(streamer) as playerSaveFile;

                if (SaveFilesArray[x].playerName == playerData.playerName && SaveFilesArray[x].saveIndex == playerData.saveIndex)
                {
                    SaveFilesArray[x].mapName = playerData.mapName;
                    SaveFilesArray[x].peopleSaved = playerData.peopleSaved;
                    SaveFilesArray[x].playTime += playerData.playTime;
                    
                    formatterr.Serialize(streamer, SaveFilesArray[x]);
                    break;
                }
            }
        }
        
        streamer.Close();
    }
    
    public static playerSaveFile[] LoadFile()
    {
        string path = Path.Combine(Application.persistentDataPath);

        var pathDir = new DirectoryInfo(path);

        var dirFiles = pathDir.GetFiles();
        
        playerSaveFile[] saveFile = new playerSaveFile[dirFiles.Length];

        var switchzada = false;
        
        if(returnSaveFiles(dirFiles, switchzada));
        {
            var falso = false;

            BinaryFormatter formatterr = new BinaryFormatter();
            FileStream streamer = new FileStream(path, FileMode.Open);

            for (int x = 0; x < dirFiles.Length; x++)
            {
                saveFile[x] = formatterr.Deserialize(streamer) as playerSaveFile;
            }

            streamer.Close();
        }
        
        return saveFile;
    }

    public static bool returnSaveFiles(FileInfo[] array, bool state)
    {
        if (array[0] != null)
        {
            state = true;
        }
        else
        {
            state = false;
        }

        return state;
    }

    public static bool CheckIfFileExist()
    {
        BinaryFormatter formatterr = new BinaryFormatter();
        
        var returnBool = false;
        
        string path = Path.Combine(Application.persistentDataPath);

        FileStream streamer = new FileStream(path, FileMode.Open);
        
        var pathDir = new DirectoryInfo(path);

        var dirFiles = pathDir.GetFiles();

        playerSaveFile[] SaveFilesArray = new playerSaveFile[dirFiles.Length];
        
        if (dirFiles[0] != null)
        {
            for (int x = 0;x < dirFiles.Length; x++)
            {
                SaveFilesArray[x] = formatterr.Deserialize(streamer) as playerSaveFile;

                if (SaveFilesArray[x].playerName == playerData.playerName && SaveFilesArray[x].saveIndex == playerData.saveIndex)
                {
                    returnBool = true;
                    break;
                }
            }
        }
        
        streamer.Close();
        return returnBool;
    }*/
}
