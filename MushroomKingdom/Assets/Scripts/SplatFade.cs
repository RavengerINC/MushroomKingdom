using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SplatFade : MonoBehaviour
{
    [SerializeField] private DecalProjector m_decalProjector;

    private void Start()
    {
        m_decalProjector = GetComponentInChildren<DecalProjector>();
    }

    //private IEnumerator FadeAlphaToZero(DecalProjector decalProjector, float duration)
    //{
    //    float startOpacity = 1.0f;
    //    float endOpacity = 0.0f;
    //    float time = 0;

    //    while (time < duration)
    //    {
    //        time += Time.deltaTime;
    //        decalProjector.
    //        renderer.color = Color.Lerp(startColor, endColor, time / duration);
    //        yield return null;
    //    }
    //}
}
