using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameplayOrquestator : MonoBehaviour
{
    public UnityEvent OnPlayerDeadEvent = new UnityEvent();
    private void OnEnable()
    {
        
        PlayerDamageableBehaviour.OnPlayerDeadEvent += OnPlayerDead;
    }

    private void OnDisable()
    {
        PlayerDamageableBehaviour.OnPlayerDeadEvent -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        Debug.Log("DEAD!");
        OnPlayerDeadEvent?.Invoke();
        //TODO: Implementar controles para cuando el jugador muere
    }
}
