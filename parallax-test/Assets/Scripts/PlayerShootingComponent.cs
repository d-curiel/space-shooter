using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class PlayerShootingComponent : MonoBehaviour
{
    public UnityEvent OnShootInputEvent = new UnityEvent();
    public UnityEvent OnShootReleaseEvent = new UnityEvent();
    public void OnShootInput(CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            OnShootInputEvent?.Invoke();
        } else
        {
            OnShootReleaseEvent?.Invoke();
        }


    }
}
