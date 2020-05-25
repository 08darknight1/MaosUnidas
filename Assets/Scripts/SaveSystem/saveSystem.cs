using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem
{
    public static void CreateNewSaveFile()
    {        
        playerSaveFile saveFile = new playerSaveFile();

        saveFile.playTime += GameObject.Find("PlayTimeClock").GetComponent<playTimeClock>().timePassed;

        Debug.Log(saveFile.playTime);
        
        BinaryFormatter formatterr = new BinaryFormatter();

        string namer = saveFile.playerName;

        string allTogether = "/"+namer+".08dk1";
        
        string path = Path.Combine(Application.persistentDataPath + allTogether);

        if (File.Exists(path))
        {
            FileStream streamer2 = new FileStream(path, FileMode.Open);
            
            playerSaveFile oldFile = formatterr.Deserialize(streamer2) as playerSaveFile;

            var time = oldFile.playTime;
            Debug.Log(time);
            var name = oldFile.playerName;
            var save = oldFile.saveIndex;

            Debug.Log(time);
            
            formatterr.Serialize(streamer2, saveFile);
            streamer2.Close();
            
            if (name == saveFile.playerName && save == saveFile.saveIndex)
            {
                saveFile.playTime += time;
                
                Debug.Log(time);
                
                
                streamer2 = new FileStream(path, FileMode.Create);
                formatterr.Serialize(streamer2, saveFile);
                streamer2.Close();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        
                FileInfo[] fileInfo = dir.GetFiles("*.08dk1*");

                var shitToAdd = 0;
                
                for (int x = 0; x < fileInfo.Length; x++)
                {
                    if (fileInfo[x].Name.Contains(namer))
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
            }   
        }
       
        return saveFiles;
    }
}
