using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _2023_06_08_BuildBase : MonoBehaviour
{
    [SerializeField]
    private Color normal;
    [SerializeField]
    private Color onMouse;
    private MeshRenderer renderer;
    private RaycastHit hit;
    private bool buildMode = false;
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (!buildMode)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                renderer.material.color = onMouse;
                if (Input.GetMouseButtonDown(0))
                {
                    buildMode = true;
                    _2023_06_08_BuildUI buildUI = GameManager.UI.ShowInGameUI<_2023_06_08_BuildUI>("UI/BuildInGameUI");
                    buildUI.SetTarget(transform);
                }
            }
            else
            {
                renderer.material.color = normal;
            }
        }
    }
    public void BuildTower(_2023_06_08_ScriptableObject data)
    {
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(data.Towers[0].tower, transform.position, transform.rotation);
    }
    public void ExitBuildMode()
    {
        buildMode = false;
    }
}
