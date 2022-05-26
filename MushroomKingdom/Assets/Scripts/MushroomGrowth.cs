using UnityEngine;

public class MushroomGrowth : MonoBehaviour
{
    //[SerializeField]
    //public float MaxGrowth = 5.0f;
    //public float CurrentGrowth = 0.0f;

    //void Update()
    //{
    //    var dt = Time.deltaTime;
    //    CurrentGrowth = Mathf.Clamp(CurrentGrowth + dt, 0f, MaxGrowth);
    //    var scaling = 1.0f + (CurrentGrowth / MaxGrowth);
    //    gameObject.transform.localScale = new Vector3() { x = scaling, y = scaling, z = scaling };
    //}

    //-------------------------------

    [SerializeField] float m_explosionRadiusMax = 5.0f;
    [SerializeField] float m_explosionRadiusMin = 1.0f;
    [SerializeField] float m_growthDuration = 5.0f;
    [SerializeField] float m_maxScale = 3.0f;

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
        //float newScaleFloat = Mathf.Lerp(0.0f, m_maxScale, growthPercent);
        //Vector3 newScaleVector = new Vector3(newScaleFloat, newScaleFloat, newScaleFloat);
        //transform.localScale = newScaleVector;

        float animationFrame = Mathf.Lerp(firstFrameOfAnim, lastFrameOfAnim, growthPercent);
        meshRenderer.material.SetFloat("_displayFrame", animationFrame);
    }
}
