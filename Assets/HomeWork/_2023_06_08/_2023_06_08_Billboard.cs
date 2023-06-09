using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_08_Billboard : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
