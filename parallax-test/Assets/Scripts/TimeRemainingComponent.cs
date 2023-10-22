using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeRemainingComponent : MonoBehaviour
{
    public float totalTime = 60.0f; // Tiempo total de la partida en segundos
    private float middleTime; // Tiempo total de la partida en segundos
    private bool middleTimeBarrier = false; // Tiempo total de la partida en segundos
    private float lastSeconds; // Tiempo total de la partida en segundos
    private bool lastSecondsBarrier = false; // Tiempo total de la partida en segundos
    private float updateSpeed = 1.0f; // Velocidad de actualización del Slider
    private Slider slider; // Referencia al componente Slider
    private float targetValue; // Valor objetivo del Slider
    private float currentTime; // Tiempo actual
    public UnityEvent OnTimeEnd = new UnityEvent();
    public UnityEvent OnMiddleTime = new UnityEvent();
    public UnityEvent OnLastSeconds = new UnityEvent();

    private void Start()
    {
        slider = GetComponent<Slider>();
        targetValue = 1.0f; // El valor inicial es 1.0 (barra llena)
        currentTime = totalTime; // Establece el tiempo actual al tiempo total inicial
        middleTime = totalTime / 2;
        lastSeconds = totalTime - middleTime / 2;
    }

    private void Update()
    {
        // Actualiza el tiempo actual
        currentTime -= Time.deltaTime;
        if (!middleTimeBarrier)
        {
            middleTime -= Time.deltaTime;
        }
        if (!lastSecondsBarrier)
        {
            lastSeconds -= Time.deltaTime;
        }

        // Asegura que el tiempo actual esté dentro de los límites
        currentTime = Mathf.Clamp(currentTime, 0f, totalTime);

        // Actualiza el valor objetivo del Slider en función del tiempo restante
        float normalizedValue = currentTime / totalTime;
        targetValue = normalizedValue;

        // Interpola suavemente hacia el valor objetivo
        slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * updateSpeed);

        // Comprueba si se ha agotado el tiempo de la partida
        if (currentTime <= 0)
        {
            OnTimeEnd?.Invoke();
        }
        if (middleTime <= 0 && !middleTimeBarrier)
        {
            middleTimeBarrier = true;
            OnMiddleTime?.Invoke();
        }
        if (lastSeconds <= 0 && !lastSecondsBarrier)
        {
            lastSecondsBarrier = true;
            OnLastSeconds?.Invoke();
        }
    }

    public void ResetTimer()
    {
        targetValue = 1.0f;
        currentTime = totalTime; // Reinicia el tiempo actual al tiempo total inicial
    }
}
