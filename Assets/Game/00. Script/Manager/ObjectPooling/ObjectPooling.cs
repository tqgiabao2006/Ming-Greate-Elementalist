using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
  Dictionary<GameObject, List<GameObject>> _pool = new Dictionary<GameObject, List<GameObject>>();

   public virtual GameObject GetObj(GameObject prefabs)
   { 
      List<GameObject> listObj = new List<GameObject>();
     if(_pool.ContainsKey(prefabs))
        listObj = _pool[prefabs];

      else
      {
         _pool.Add(prefabs, listObj);
      }
      foreach(GameObject g in listObj)
      {
         if(g.activeSelf)continue;

         return g;
      }
      GameObject g2 = Instantiate(prefabs, transform.position, Quaternion.identity);
      listObj.Add(g2);
      return g2;
   }

}
