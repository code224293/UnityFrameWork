using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
        //初始化框架
        InitFramework();

        //检查热更
        CheckHotFix();



        //初始化游戏
        InitGame();
    }

    //ResMgr,UIMgr,AudioMgr,TimerMgr...
    private void InitFramework()
    {
        ResMgr.Instance.Init();
        UIMgr.Instance.Init();
    }

    private void CheckHotFix()
    {

    }

    private void InitGame()
    {

    }

}
