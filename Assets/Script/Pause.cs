using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Button resumeButton;      // Reference to the resume button
    public GameObject pauseMenu;     // Reference to the pause menu object
    private bool isPaused = false;   // Track pause state

    void Awake()
    {
        // Add listener to the resume button's onClick event
        resumeButton.onClick.AddListener(OnResumePressed);
        
        // Make sure pause menu is disabled at start
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    void OnResumePressed()
    {
        ResumeGame();
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
}