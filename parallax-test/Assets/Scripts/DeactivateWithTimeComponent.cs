using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeactivateWithTimeComponent : MonoBehaviour
{
    public UnityEvent OnDeactivate = new UnityEvent();
    public float totalTime = 60.0f; 

    private void OnEnable()
    {
        StartCoroutine(AwaitToTurnOff());
    }

    private IEnumerator AwaitToTurnOff()
    {
        yield return new WaitForSeconds(totalTime);
        OnDeactivate?.Invoke();
        gameObject.SetActive(false);
    }
}
