using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_07_OpenInventory : _2023_06_07_PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["InventoryButton"].onClick.AddListener(() => { OpenInventoryUI(); });
    }
    public void OpenInventoryUI()
    {
        GameManager.UI.ShowPopUpUI<_2023_06_07_PopUpUI>("UI/InventoryUI");
    }
}
