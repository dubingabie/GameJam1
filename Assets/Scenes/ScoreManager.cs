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
    }

    void Start()
    {
        // Create Canvas if it doesn't exist
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObject = new GameObject("Canvas");
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
        }

        // Create Text if not assigned
        if (scoreText == null)
        {
            GameObject textObject = new GameObject("ScoreText");
            textObject.transform.SetParent(canvas.transform);
            scoreText = textObject.AddComponent<Text>();
            
            // Set default properties
            scoreText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            scoreText.fontSize = 24;
            scoreText.color = Color.white;
            scoreText.text = "Diamonds: 0";
            
            // Position the text in the top-left corner
            RectTransform rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 1);
            rectTransform.anchorMax = new Vector2(0, 1);
            rectTransform.pivot = new Vector2(0, 1);
            rectTransform.anchoredPosition = new Vector2(10, -10);
        }
        
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