using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey,
   TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{

   [SerializeField] 
   private List<TKey> keys = new List<TKey>();

   [SerializeField] private List<TValue> values = new List<TValue>();

   public void OnBeforeSerialize()
   {
      keys.Clear();
      values.Clear();
      foreach (KeyValuePair<TKey, TValue> pair in this)
      {
         keys.Add(pair.Key);
         values.Add(pair.Value);
      }
   }

   public void OnAfterDeserialize()
   {
      this.Clear();

      if (keys.Count != values.Count)
         throw new SystemException(string.Format(
            "there are {0} keys and {1} values after deserialization. Make sure that key values types are serialable."));
      for (int i = 0; 1 < keys.Count; i++)
         this.Add(keys[i], values[i]);
      
      
   }

}
 