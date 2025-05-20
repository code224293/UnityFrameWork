using System.Windows;
using UnityEditor;
using UnityEngine;

public class GetPath
{
    [MenuItem("GameObject/Get Path", false, 0)]
    private static void GetPathOfSelectedObject()
    {
        GameObject selectedObject = Selection.activeGameObject;

        if (selectedObject != null)
        {
            string path = GetGameObjectPath(selectedObject);
            //∏¥÷∆µΩºÙ«–∞Â
            GUIUtility.systemCopyBuffer = path;
        }
        else
        {
            Debug.LogWarning("No object selected.");
        }
    }

    private static string GetGameObjectPath(GameObject obj)
    {
        string path = obj.name;
        while (obj.transform.parent != null)
        {
            path= obj.transform.parent.name + "/" + path;
            obj = obj.transform.parent.gameObject;
        }
        return path;
    }
}
