using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This will be a singleton manager for the score

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int diamondCount = 0;

    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("ScoreManager initialized");
        }
        else
        {
            Destroy(gameObject);
        }

        // Check if scoreText is assigned
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned to ScoreManager!");
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void IncrementDiamonds()
    {
        diamondCount++;
        Debug.Log($"Diamond collected! Count is now: {diamondCount}");
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Diamonds: {diamondCount}";
            Debug.Log($"Updated score text to: Diamonds: {diamondCount}");
        }
        else
        {
            Debug.LogError("Score Text is null!");
        }
    }
}