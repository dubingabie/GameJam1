using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Make sure this is at the top of your script

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI scoreText;

    private int diamonds = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        UpdateScore();
    }

    public void AddDiamond()
    {
        diamonds++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = $"Diamonds: {diamonds}";
    }
}