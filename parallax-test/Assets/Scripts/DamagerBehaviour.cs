using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerBehaviour : MonoBehaviour
{

    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyDamage(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ApplyDamage(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ApplyDamage(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ApplyDamage(collision.gameObject);
    }

    private void ApplyDamage(GameObject gameObject)
    {
        gameObject.TryGetComponent<DamageableBehaviour>(out DamageableBehaviour damageable);
        if (damageable)
        {
            damageable.TakeDamage(damage);
        }
    }
}
