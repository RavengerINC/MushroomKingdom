using System.Collections;
using UnityEngine;

public class MushroomGrower : MonoBehaviour
{
    private Renderer myRenderer;

    public int startFrame = 1;
    public int endFrame = 24;
    public float growTimeInSeconds = 1;

    private void Start()
    {
        myRenderer = GetComponentInChildren<Renderer>();
        myRenderer.material.SetFloat("_displayFrame", 1);
    }

    public void Grow()
    {
        StartCoroutine(GrowMushroom());
    }

    public void Shrink()
    {
        StartCoroutine(ShrinkMushroom());
    }

    public void Reset()
    {
        myRenderer.material.SetFloat("_displayFrame", 1);
    }

    private IEnumerator GrowMushroom()
    {
        float timeLeft = growTimeInSeconds;

        while (timeLeft > 0)
        {
            float percent = Mathf.Lerp(startFrame, endFrame, 1 - timeLeft);
            myRenderer.material.SetFloat("_displayFrame", percent);
            timeLeft -= Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ShrinkMushroom()
    {
        float timeLeft = growTimeInSeconds;

        while (timeLeft > 0)
        {
            float percent = Mathf.Lerp(endFrame, startFrame, 1 - timeLeft);
            myRenderer.material.SetFloat("_displayFrame", percent);
            timeLeft -= Time.deltaTime;
            yield return null;
        }
    }
}
