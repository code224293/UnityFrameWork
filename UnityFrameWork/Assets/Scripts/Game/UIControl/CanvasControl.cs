using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl: UIControlBase
{
    protected override void Awake()
    {
        base.Awake();

        AddButtonListener("Canvas/Button", OnClickButton1);
    }

    private void OnClickButton1()
    {
        Debug.Log("Button1 clicked");
    }
}
