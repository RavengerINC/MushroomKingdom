using System.Collections;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    public GameObject antNest;
    private float antsPerSecond;

    void Awake() {
        antsPerSecond = 0.1f;
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
        while (true)
        {
            yield return new WaitForSeconds(duration);
            Instantiate(antPrefab, antNest.transform.position, Quaternion.identity);
        }
    }
}
