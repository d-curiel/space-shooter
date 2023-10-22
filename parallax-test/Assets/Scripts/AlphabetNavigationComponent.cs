using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlphabetNavigationComponent : MonoBehaviour
{
    [SerializeField]
    public TMP_Text textMesh;
    private char currentLetter = 'A';

    private void Start()
    {
        UpdateLetterDisplay();
    }

    public void NextLetter()
    {
        if (currentLetter < 'Z')
        {
            currentLetter++;
        }
        else
        {
            currentLetter = 'A';
        }

        UpdateLetterDisplay();
    }

    public void PreviousLetter()
    {
        if (currentLetter > 'A')
        {
            currentLetter--;
        }
        else
        {
            currentLetter = 'Z';
        }

        UpdateLetterDisplay();
    }

    public string GetLetter()
    {
        return currentLetter.ToString();
    }

    private void UpdateLetterDisplay()
    {
        textMesh.text = currentLetter.ToString();
    }
}
