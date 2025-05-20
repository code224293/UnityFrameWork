
using UnityEditor;

public class Test1
{
    [MenuItem("GMCommand/TestUIMgr")]
    public static void TestUIMgr()
    {
        UIMgr.Instance.ShowUI("Canvas");
    }
}
