using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomGrowth : MonoBehaviour
{
    [SerializeField]
    public float MaxGrowth = 5.0f;
    public float CurrentGrowth = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        CurrentGrowth = Mathf.Clamp(CurrentGrowth + dt, 0f, MaxGrowth);
        var scaling = 1.0f + (CurrentGrowth / MaxGrowth);
        gameObject.transform.localScale = new Vector3() { x = scaling, y = scaling, z = scaling };
    }
}
