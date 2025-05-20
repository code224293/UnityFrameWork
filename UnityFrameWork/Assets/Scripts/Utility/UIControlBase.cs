using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIControlBase : MonoBehaviour
{
    protected Dictionary<string, GameObject> view;

    protected virtual void Awake()
    {
        LoadView(gameObject,"");
    }

    private void LoadView(GameObject root,string path)
    {
        foreach (Transform child in root.transform)
        {
            string curentPath = path + child.name;
            if(view.ContainsKey(curentPath))continue;

            view.Add(curentPath, child.gameObject);
            LoadView(child.gameObject, curentPath + "/");
        }
    }

    public void AddButtonListener(string path, UnityAction listener)
    {
        if(!view.ContainsKey(path))return;

        view[path].GetComponent<Button>().onClick.AddListener(listener);
    }

}
