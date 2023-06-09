using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_08_Tower : MonoBehaviour
{
    public _2023_06_08_ScriptableObject data;

    private void Awake()
    {
        data = GameManager.Resource.Load<_2023_06_08_ScriptableObject>("Data/Tower1");
    }
}
