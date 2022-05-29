using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SplatFade : MonoBehaviour
{
    [SerializeField] private DecalProjector m_decalProjector;
    [SerializeField] private float m_duration = 10.0f;

    private void Start()
    {
        m_decalProjector = GetComponentInChildren<DecalProjector>();
        StartCoroutine(FadeAlphaToZero(m_decalProjector, m_duration));
    }

    private IEnumerator FadeAlphaToZero(DecalProjector decalProjector, float duration)
    {
        decalProjector.fadeFactor = 1.0f;

        float startOpacity = 1.0f;
        float endOpacity = 0.0f;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            decalProjector.fadeFactor = Mathf.Lerp(startOpacity, endOpacity, time / duration);
            yield return null;
        }
    }
}
