using System;
using UnityEngine;

public class UIMgr : UnitySingleton<UIMgr>
{
    string rootpath = "GUI/";

    public void ShowUI(string name)
    {
        string fullPath = rootpath + name+".prefab";
        ResMgr.Instance.LoadAssetAsync<GameObject>(fullPath, (obj) =>
        {
            if (obj != null)
            {
                GameObject go = Instantiate(obj);
                go.name = name;
                go.transform.SetParent(transform);

                string controlName = name + "Controller";
                Type type = Type.GetType(controlName);
                if (type != null)
                {
                    //Ìí¼ÓController×é¼þ
                    go.AddComponent(type);
                }
            }
            else
            {
                Debug.LogError("Failed to load prefab: " + fullPath);
            }
        });
    }
}
