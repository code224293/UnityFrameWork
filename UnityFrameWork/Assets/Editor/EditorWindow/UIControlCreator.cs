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
        GUILayout.Label("ѡ��һ��UI��ͼ��");

        selectedPrefab= Selection.activeObject as GameObject;
        if (selectedPrefab != null&& selectedPrefab.GetComponent<RectTransform>())
        {
            GUILayout.Label(selectedPrefab.name);

            string file = filePath + selectedPrefab.name + "Control.cs";
            GUILayout.Label("����λ�ã�" + file);

            string action = "����";
            if (UIControlCreatorUti.CheckExist(file))
            {
                action = "����";
            }

            if (GUILayout.Button(action + $"{selectedPrefab.name + "Control.cs"}"))
            {
                UIControlCreatorUti.CreateUIControl(filePath, selectedPrefab.name+ "Control");
            }
        }
        else
        {
            GUILayout.Label("δѡ��");
        }
    }


    private void OnSelectionChange()
    {
        Repaint();
    }
}
