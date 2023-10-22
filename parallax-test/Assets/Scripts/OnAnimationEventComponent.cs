using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAnimationEventComponent : MonoBehaviour
{
    public UnityEvent OnAnimationEvent = new UnityEvent();

    public void OnAnimationEventFire()
    {
        OnAnimationEvent?.Invoke();
    }
}
