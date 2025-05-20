using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UIControlCreatorUti
{
    public static void CreateUIControl(string path, string className)
    {
        string scriptContent =
@"using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class " + className + @": UIControlBase
{
    protected override void Awake()
    {
        base.Awake();
    }
}
";

        string file = path + "/" + className + ".cs";
        if (CheckExist(file))File.Delete(file);
        
        File.WriteAllText(file, scriptContent);
        //±£´æ£¬Ë¢ÐÂ
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }

    public static bool CheckExist(string file)
    {
        if (System.IO.File.Exists(file))
        {
            return true;
        }
        return false;
    }
}
