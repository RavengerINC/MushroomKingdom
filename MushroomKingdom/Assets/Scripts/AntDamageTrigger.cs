using UnityEngine;

public class AntDamageTrigger : MonoBehaviour
{
    public HeroMushroom heroShroom;

    private void OnTriggerEnter(Collider other)
    {
        heroShroom.TakeDamage();
        // TODO: Figure out how to best make this only apply to ants.
        // Can set a tag or layer for the ants and check against that
        Destroy(other.gameObject); 
    }
}
