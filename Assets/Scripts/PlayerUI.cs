using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    private int streak = 0;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject BegginingUI;
    [SerializeField] private TextMeshProUGUI streakText;
    [SerializeField] private float popOutDuration = 0.5f;
    [SerializeField] private Vector3 popOutScale = new Vector3(1.5f, 1.5f, 1.5f);
    
    private void OnEnable()
    {
        PlayerScript.increaseWindStreak += IncreaseStreak;
        PlayerScript.HideStreak += hideUI;
        PlayerScript.HitGround += ShowEndGame;
    }

    private void OnDisable()
    {
        PlayerScript.increaseWindStreak -= IncreaseStreak;
        PlayerScript.HideStreak -= hideUI;
        PlayerScript.HitGround -= ShowEndGame;

    }

    private void ShowEndGame()
    {
        endGameUI.SetActive(true);
    }
    private void hideUI()
    {
        BegginingUI.gameObject.SetActive(false);
    }
    private void IncreaseStreak()
    {
        streak += 1;
        streakText.text = "x" + streak;
        if (streak % 5 == 0)
        {
            StartCoroutine(PopOutCoroutine());
        }
        
        switch (streak)
        {
            case 10:
                streakText.color = Color.yellow;
                break;
            case 20:
                streakText.color = Color.red;
                break;
        }
    }
    
    private IEnumerator PopOutCoroutine()
    {
        Vector3 originalScale = streakText.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < popOutDuration)
        {
            streakText.transform.localScale = Vector3.Lerp(originalScale, popOutScale, elapsedTime / popOutDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        streakText.transform.localScale = originalScale;
    }

    public void onEndButtonPress()
    {
        mainMenu.SetActive(true);
        endGameUI.SetActive(false);
    }
    
}
