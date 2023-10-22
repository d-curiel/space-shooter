using UnityEngine;
using UnityEngine.Events;

public class OnLeaveScreenEventComponent : MonoBehaviour
{
    public UnityEvent OnBecameInvisibleEvent = new UnityEvent();
    private void OnBecameInvisible()
    {
        OnBecameInvisibleEvent?.Invoke();
    }
}
