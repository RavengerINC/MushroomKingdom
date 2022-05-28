using System;
using System.Collections;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    public GameObject antNest;
    private float antsPerSecond;
    private DateTime gameStartTime;

    void Awake() {
        antsPerSecond = 0.1f;
        gameStartTime = DateTime.Now;
    }

    void Start()
    {
        StartTimer(1 / antsPerSecond);
    }

    public void StartTimer(float duration)
    {
        StartCoroutine(RunTimer(duration));
    }

    private IEnumerator RunTimer(float duration)
    {
        var antDelay = duration;
        while (true)
        {
            var minutesSinceStart = (float)(DateTime.Now - gameStartTime).TotalMinutes;
            var scaledDelay = antDelay + (0.1f * minutesSinceStart);
            yield return new WaitForSeconds(scaledDelay);
            Instantiate(antPrefab, antNest.transform.position, Quaternion.identity);
        }
    }
}
