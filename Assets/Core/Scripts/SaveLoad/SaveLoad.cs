using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public static class SaveLoad
{
   public static UnityAction OnSaveGame;
   public static UnityAction<SaveData> OnLoadGame;

   private static string directory = "/SaveData/";
   private static string fileName = "SaveGame.sav";
   
   public static bool Save(SaveData data)
   {
      OnSaveGame?.Invoke();

      string dir = Application.persistentDataPath + directory;

      if (!Directory.Exists(dir))
      
         Directory.CreateDirectory(dir);

      string json = JsonUtility.ToJson(data, true);
      File.WriteAllText(dir + fileName, json);
      
      Debug.Log("Saving game");
      
      return true;
   }

   public static SaveData Load()
   {
      string FullPath = Application.persistentDataPath + directory + fileName;
      SaveData data = new SaveData();

      if (File.Exists(FullPath))
      {
         string json = File.ReadAllText(FullPath);
         data = JsonUtility.FromJson<SaveData>(json);

         OnLoadGame.Invoke(data);
      }
      else
      {
       Debug.Log("Save file does not exist!");
      }
      return data;
   }
}
 