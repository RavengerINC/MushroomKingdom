using UnityEngine;

public class AntDamageTrigger : MonoBehaviour
{
    public HeroMushroom heroShroom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AntGrunt"))
        {
            heroShroom.TakeDamage();
            other.gameObject.GetComponent<AntActions>().RemoveAnt();
        }
    }
}
