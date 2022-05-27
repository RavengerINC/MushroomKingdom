using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private int m_score;

    private TMP_Text m_scoreText;

    public static ScoreTracker Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        m_scoreText = GetComponentInChildren<TMP_Text>();
        m_score = 0;
        UpdateText();
    }

    public void IncrementScore(int amount)
    {
        m_score += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        m_scoreText.text = $"{m_score}";
    }
}
