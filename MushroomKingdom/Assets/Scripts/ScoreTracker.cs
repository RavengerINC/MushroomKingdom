using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        var tmpText = gameObject.GetComponent<TMP_Text>();
        tmpText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AntKilled() {
        Score += 10;
        var tmpText = gameObject.GetComponent<TMP_Text>();
        tmpText.text = $"{Score}";
    }
}
