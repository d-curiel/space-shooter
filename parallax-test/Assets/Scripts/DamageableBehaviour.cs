using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehaviour : MonoBehaviour
{
    //TODO: Incluir configuración
    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int currentHealth;
    private bool isDead = false;
    public UnityEvent OnBeginDeathEvent = new UnityEvent();
    public UnityEvent OnEndDeathEvent = new UnityEvent();
    public UnityEvent OnTakeDamage = new UnityEvent();
    public UnityEvent OnRespawn = new UnityEvent();

    private void Awake()
    {
        ResetHealth();
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            OnBeginDeath();
        }
    }

    private void OnEnable()
    {
        isDead = false;
        ResetHealth();
        OnRespawn?.Invoke();
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnTakeDamage?.Invoke();
    }

    public void Heal(int health)
    {
        currentHealth += health;
    }

    public void InstaKill()
    {
        TakeDamage(maxHealth);
    }

    private void OnBeginDeath()
    {
        isDead = true;
        OnBeginDeathEvent?.Invoke();
    }

    private void OnEndDeath()
    {
        OnEndDeathEvent?.Invoke();
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;

    }

}
