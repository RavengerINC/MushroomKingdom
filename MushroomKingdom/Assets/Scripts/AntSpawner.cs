using System.Collections;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    public GameObject antNest;

    void Start()
    {
        StartTimer(4);
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
