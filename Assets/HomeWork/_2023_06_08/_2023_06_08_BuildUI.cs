using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_08_BuildUI : _2023_06_07_BaseUI
{
    public Transform followTarget;
    public Vector3 followOffset;
    public GameObject buildPlace;
    private _2023_06_08_BuildBase build;

    protected override void Awake()
    {
        base.Awake();
        buttons["BlockerButton"].onClick.AddListener(() => { CloseUI(); });
        buttons["TowerButton"].onClick.AddListener(() => { BuildArchorTower(); });
        build = buildPlace.GetComponent<_2023_06_08_BuildBase>();
    }
    protected virtual void LateUpdate()
    {
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + followOffset;
        }
    }

    public void SetTarget(Transform target)
    {
        followTarget = target;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + followOffset;
        }
    }

    public void SetOffset(Vector3 offset)
    {
        followOffset = offset;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + followOffset;
        }
    }

    public override void CloseUI()
    {
        build.ExitBuildMode();
        base.CloseUI();

        GameManager.UI.CloseInGameUI(this);
    }

    public void BuildArchorTower()
    {
        _2023_06_08_ScriptableObject archorTowerData = GameManager.Resource.Load<_2023_06_08_ScriptableObject>("Data/Tower1");
        build.BuildTower(archorTowerData);

        CloseUI();
    }
}
