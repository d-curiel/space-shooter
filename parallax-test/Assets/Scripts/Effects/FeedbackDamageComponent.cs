using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackDamageComponent : MonoBehaviour
{
    [SerializeField]
    private Material damageMaterial;

    private GameObject _damageIndicator;
    private SpriteRenderer _sr;
    private SpriteRenderer _parentSr;
    private void Awake()
    {
        _parentSr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        ActivateBlinking();


    }

    private void OnDisable()
    {
        Destroy(_sr);
    }

    private void ActivateBlinking()
    {
        _damageIndicator = new GameObject("Blinker");
        _damageIndicator.transform.parent = transform;

        _damageIndicator.transform.localPosition = Vector2.zero;
        _damageIndicator.transform.localRotation = Quaternion.identity;
        _damageIndicator.transform.localScale = Vector3.one;

        _sr = _damageIndicator.AddComponent<SpriteRenderer>();
        _sr.sprite = _parentSr.sprite;
        _sr.material = damageMaterial;

        _sr.sortingLayerName = _parentSr.sortingLayerName;
        _sr.sortingOrder = _parentSr.sortingOrder - 1;
    }

    public void StartGiveFeedback()
    {
        if (_sr)
        {
            StartCoroutine(GiveFeedback());
        }
        
    }

    private IEnumerator GiveFeedback()
    {

        _sr.sortingOrder = _parentSr.sortingOrder + 1;
        yield return new WaitForSeconds(00.2f);
        _sr.sortingOrder = _parentSr.sortingOrder - 1;
    }
}
