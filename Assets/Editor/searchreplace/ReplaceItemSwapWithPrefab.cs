#define PSR_FULL
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace sr
{ 
  [System.Serializable]
  public class ReplaceItemSwapWithPrefab : ReplaceItem
  {
    public ObjectID objID;

    public bool rename;
    public bool updateTransform;

    public override void Draw()
    {
#if PSR_FULL
      GUILayout.BeginHorizontal();
      Type fieldType = type != null ? type : typeof(UnityEngine.Object);

      GUILayout.Label(Keys.Replace, GUILayout.Width(SRWindow.compactLabelWidthNP));
      UnityEngine.Object newObj = EditorGUILayout.ObjectField( objID.obj, fieldType, true);

      if(newObj != null)
      {
        if(!fieldType.IsAssignableFrom(newObj.GetType()))
        {
          // Debug.Log("[ReplaceItemObject] nulling out!"+newObj.GetType() + " : " +fieldType );
          newObj = null;
        }else
        if(!PrefabUtil.isPrefab(newObj))
        {
          Debug.Log("[Search & Replace] "+ newObj.name + " is not a prefab.");
          newObj = null;
        }
      }
      if(objID.obj != newObj)
      {
        objID.SetObject(newObj);
        SRWindow.Instance.PersistCurrentSearch();
      }
      drawSwap();
      GUILayout.EndHorizontal();
      GUILayout.BeginHorizontal();
      GUILayout.Space(SRWindow.compactLabelWidth);
      GUILayout.BeginVertical();
      bool newRename = EditorGUILayout.Toggle("Keep Name", rename);
      {
        if(newRename != rename)
        {
          rename = newRename;
          SRWindow.Instance.PersistCurrentSearch();
        }
      }
      bool newUpdateTransform = EditorGUILayout.Toggle("Keep Transform Values", updateTransform);
      {
        if(newUpdateTransform != updateTransform)
        {
          updateTransform = newUpdateTransform;
          SRWindow.Instance.PersistCurrentSearch();
        }
      }
      GUILayout.EndVertical();
      GUILayout.EndHorizontal();

#endif
    }

    public override bool IsValid()
    {
      return objID.obj != null;
    }

    // Fixes nulls in serialization manually...*sigh*.
    public override void OnDeserialization()
    {
      popupLabel = "Swap With Prefab";
      if(objID == null)
      {
        objID = new ObjectID();
      }
      objID.OnDeserialization();
    }

    protected override void replace(SearchJob job, SerializedProperty prop, SearchResult result)
    {
#if PSR_FULL
      // Debug.Log("[ReplaceItemSwapObject] Replacing!");
      UnityEngine.Object objToSwap = prop.serializedObject.targetObject;

      ObjectID swapObjID = new ObjectID(objToSwap);
      if(swapObjID.isSceneObject)
      {
        GameObject gameObjToSwap = swapObjID.GetGameObject();
        if(gameObjToSwap != null)
        {
          PrefabUtil.SwapPrefab(job, result, gameObjToSwap, objID.GetGameObject(), updateTransform, rename);
          result.actionTaken = SearchAction.ObjectSwapped;

        }else{
          // Debug.Log("[ReplaceItemSwapObject] null gameObjToSwap");
        }
      }else{
        // Debug.Log("[ReplaceItemSwapObject] not a scene object.");
      }
#endif 

    }


  } // End Class
} // End Namespace