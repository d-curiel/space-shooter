using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnEnableComponent : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
