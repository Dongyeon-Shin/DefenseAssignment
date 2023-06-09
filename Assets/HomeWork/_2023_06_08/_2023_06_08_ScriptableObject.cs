using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Data/Tower")]
public class _2023_06_08_ScriptableObject : ScriptableObject
{
    [SerializeField] TowerInfo[] towers;
    public TowerInfo[] Towers { get { return towers; } }

    [Serializable]
        public class TowerInfo
        {
            public string name;
            public string description;

            public _2023_06_08_Tower tower;

            public float hp;
            public float cost;
            public float damage;
        }
}
