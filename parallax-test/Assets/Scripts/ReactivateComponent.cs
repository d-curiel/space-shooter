using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReactivateComponent : MonoBehaviour
{
    
    public UnityEvent OnReactivate = new UnityEvent();

    public void Reactivate()
    {
        OnReactivate?.Invoke();
    }
}
