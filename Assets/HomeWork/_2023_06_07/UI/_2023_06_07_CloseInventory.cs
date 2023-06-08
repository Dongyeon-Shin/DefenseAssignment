using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_07_CloseInventory : _2023_06_07_PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        //buttons["OkButton"].onClick.AddListener(() => { Application.Quit(); });
        buttons["CloseButton"].onClick.AddListener(() => { CloseUI(); });
    }
}
