using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
        //��ʼ�����
        InitFramework();

        //����ȸ�
        CheckHotFix();



        //��ʼ����Ϸ
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
