using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_07_PopUpUI : _2023_06_07_BaseUI
{
    public override void CloseUI()
    {
        base.CloseUI();

        GameManager.UI.ClosePopUpUI();
    }
}
