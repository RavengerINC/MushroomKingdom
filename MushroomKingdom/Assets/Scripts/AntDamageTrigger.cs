using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntDamageTrigger : MonoBehaviour
{
    public HeroMushroom heroShroom;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("An object entered.");
        heroShroom.TakeDamage();
        // TODO: Figure out how to best make this only apply to ants.
        Destroy(other.gameObject); 
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("An object is still inside of the trigger");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("An object left.");
    }
}
