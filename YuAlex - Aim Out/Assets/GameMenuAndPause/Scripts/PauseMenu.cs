using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using InfimaGames.LowPolyShooterPack;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuSceneName = string.Empty;

    [SerializeField] private bool isPaused = false;
    [SerializeField] private KeyCode pauseKey = KeyCode.None;

    public Button quitButton;
    public Button continueButton;

    public GameObject pauseBorder;

    private void Start()
    {
        quitButton?.onClick.AddListener(QuitGame);
        continueButton?.onClick.AddListener(ContinueGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if(isPaused)
                isPaused = false;
            else
                isPaused = true;

            PauseGame(isPaused);
        }
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            TogglePauseBorder(true);
            ToggleControls(false);
            ToggleCursor(true);
            Time.timeScale = 0;
        }
        else
        {
            TogglePauseBorder(false);
            ToggleCursor(false);
            ToggleControls(true);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync(mainMenuSceneName);
        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        if (isPaused)
        {
            isPaused = false;
            TogglePauseBorder(false);
            ToggleControls(true);
            ToggleCursor(false);
            Time.timeScale = 1;
        }
    }

    void TogglePauseBorder(bool toggle)
    {
        pauseBorder.SetActive(toggle);
    }

    void ToggleControls(bool toggle)
    {
        FindObjectOfType<Movement>().enabled = toggle;
        FindObjectOfType<Character>().enabled = toggle;
        FindObjectOfType<CameraLook>().enabled = toggle;
    }

    void ToggleCursor(bool toggle)
    {
        if (!toggle)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}