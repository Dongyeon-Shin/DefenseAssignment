using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _2023_06_08 : _2023_06_08_WindowUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["WindowButton"].onClick.AddListener(() => { OpenWindowUI(); });
    }
    public void OpenWindowUI()
    {
        GameManager.UI.ShowWindowUI<_2023_06_08_WindowUI>("UI/WindowUI");
    }
}
