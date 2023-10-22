using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageableBehaviour : DamageableBehaviour
{
    public delegate void OnPlayerDead();
    public static event OnPlayerDead OnPlayerDeadEvent;

    public void PlayerIsDead()
    {
        OnPlayerDeadEvent?.Invoke();
    }
}
