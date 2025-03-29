using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    
    /// <summary>
    /// Updates the progress fill amount
    /// </param>
    /// <param name="newValue">The new value to set the progress bar to ( between 0 and 1)</param>
    public void UpdateProgressBar(float newValue)
    {
        _progressBar.value = newValue;
    }
}
