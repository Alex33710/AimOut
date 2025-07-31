using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null && Instance != this)
            Destroy(gameObject);
    }

    public int HP = 50;
    public int ballsShot = 0;
    public int Waves = 0;
    public int targetsHit = 0;

    [Header("UI")]
    public TMP_Text healthText;
    public TMP_Text ballsShotText;
    public TMP_Text waveText;

    [Header("Targets")]
    public List<GameObject> targets;

    [Header("Panels")]
    public GameObject gameOverPanel;

    public void DecreaseHP(int amount)
    {
        HP -= amount;

        if (HP <= 0)
        {
            gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void AddBallShot(int amount)
    {
        ballsShot += amount;
    }

    public void UpdateTargets(int amount)
    {
        targetsHit += amount;

        if (targetsHit == targets.Count)
        {
            ResetWave();
            Waves += 1;
        }
    }

    public void ResetWave()
    {
        foreach (var g in targets)
        {
            g.SetActive(true);
        }

        targetsHit = 0;
    }

    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = $"HP: {HP}";
        ballsShotText.text = $"Balls Shot: {ballsShot}";
        waveText.text = $"Waves: {Waves}";
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
    }
}
