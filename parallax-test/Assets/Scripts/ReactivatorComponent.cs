using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReactivatorComponent : MonoBehaviour
{

    public UnityEvent OnReactivationDone = new UnityEvent();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent<ReactivateComponent>(out ReactivateComponent reacComp);
        if (reacComp)
        {
            reacComp.Reactivate();
            OnReactivationDone?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<ReactivateComponent>(out ReactivateComponent reacComp);
        if (reacComp)
        {
            reacComp.Reactivate();
            OnReactivationDone?.Invoke();
        }
    }
}
