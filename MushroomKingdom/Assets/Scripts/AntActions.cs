using System.Collections;
using UnityEngine;

public class AntActions : MonoBehaviour
{
    [SerializeField] private GameObject deadAntPrefab;
    [SerializeField] private ParticleSystem explosionParticles;

    public void KillAnt() {
        StartCoroutine(explode());
    }

    private IEnumerator explode()
    {
        ParticleSystem ep = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        ep.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.5f);
        Instantiate(deadAntPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
