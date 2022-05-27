using UnityEngine;

public class MushroomGrowth : MonoBehaviour
{
    [SerializeField] float m_explosionRadiusMax = 5.0f;
    [SerializeField] float m_explosionRadiusMin = 1.0f;
    [SerializeField] float m_growthDuration = 5.0f;

    private float m_startTime;
    private float m_growthPercent;

    private MeshRenderer meshRenderer;
    private int firstFrameOfAnim = 1;
    private int lastFrameOfAnim = 24;

    public float ExposionRadius { 
        get
        {
            return Mathf.Lerp(m_explosionRadiusMin, m_explosionRadiusMax, m_growthPercent);
        } 
    }

    private void OnEnable()
    {
        m_startTime = Time.time;
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.material.SetFloat("_displayFrame", 1);
    }

    private void Update()
    {
        if (m_growthPercent >= 1.0f)
            return;

        m_growthPercent = Mathf.Clamp((Time.time - m_startTime) / m_growthDuration, 0, 1);
        GrowMushroom(m_growthPercent);
    }

    private void GrowMushroom(float growthPercent)
    {
        float animationFrame = Mathf.Lerp(firstFrameOfAnim, lastFrameOfAnim, growthPercent);
        meshRenderer.material.SetFloat("_displayFrame", animationFrame);
    }
}
