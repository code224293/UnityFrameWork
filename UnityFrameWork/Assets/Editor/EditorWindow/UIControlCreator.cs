using UnityEditor;
using UnityEngine;

public class UIControlCreator : EditorWindow
{
    string filePath = "Assets/Scripts/Game/UIControl/";
    GameObject selectedPrefab;

    [MenuItem("Tools/UI Control Creator")]
    public static void ShowWindow()
    {
        GetWindow<UIControlCreator>("UI Control Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("选择一个UI视图：");

        selectedPrefab= Selection.activeObject as GameObject;
        if (selectedPrefab != null&& selectedPrefab.GetComponent<RectTransform>())
        {
            GUILayout.Label(selectedPrefab.name);

            string file = filePath + selectedPrefab.name + "Control.cs";
            GUILayout.Label("生成位置：" + file);

            string action = "创建";
            if (UIControlCreatorUti.CheckExist(file))
            {
                action = "更新";
            }

            if (GUILayout.Button(action + $"{selectedPrefab.name + "Control.cs"}"))
            {
                UIControlCreatorUti.CreateUIControl(filePath, selectedPrefab.name+ "Control");
            }
        }
        else
        {
            GUILayout.Label("未选择");
        }
    }


    private void OnSelectionChange()
    {
        Repaint();
    }
}
