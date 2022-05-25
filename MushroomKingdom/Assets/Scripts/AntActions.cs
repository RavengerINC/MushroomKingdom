using System.Collections;
using UnityEngine;

public class AntActions : MonoBehaviour
{
    [SerializeField] private GameObject deadAntPrefab;
    [SerializeField] private ParticleSystem explosionParticles;

    public void KillAnt() {
        ParticleSystem ep = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        ep.GetComponent<ParticleSystem>().Play();
        Instantiate(deadAntPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
