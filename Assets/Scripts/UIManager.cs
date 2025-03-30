using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject DrinksPanel;
    [SerializeField] private GameObject MainPanel;
    
    
    public void ShowDrinksPanel()
    {
        DrinksPanel.SetActive(true);
        MainPanel.SetActive(false);
    }
    
    public void ShowMainPanel()
    {
        DrinksPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
