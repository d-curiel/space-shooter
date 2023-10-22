using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class PlayerUltimateComponent : MonoBehaviour
{
    public float totalChage = 30.0f;
    private float updateSpeed = 1.0f;
    [SerializeField]
    private Slider slider;
    private float targetValue;
    private float currentCharge;
    private bool charged;
    private bool canRecharge = false;
    public UnityEvent OnUltimateInputEvent = new UnityEvent();
    public void OnInput(CallbackContext context)
    {
        if (context.ReadValueAsButton() && charged)
        {
            charged = false;
            canRecharge = false;
            currentCharge = 0;
            UpdateSlider();
            OnUltimateInputEvent?.Invoke();
        }
    }

    private void Start()
    {
        targetValue = 1.0f; 
        currentCharge = totalChage; 
        charged = true;
    }

    private void Update()
    {
        // Actualiza el tiempo actual
        if (!charged && canRecharge)
        {
            currentCharge += Time.deltaTime;
        }
        currentCharge = Mathf.Clamp(currentCharge, 0f, totalChage);
        if (currentCharge >= totalChage)
        {
            currentCharge = totalChage;
            charged = true;
        }
        UpdateSlider();
    }

    private void UpdateSlider()
    {

        float normalizedValue = currentCharge / totalChage;
        targetValue = normalizedValue;

        slider.value = targetValue;
    }

    public void SetRechargable()
    {
        canRecharge = true;
    }
}
