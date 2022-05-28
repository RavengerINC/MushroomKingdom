using System.Collections;
using UnityEngine;

public class AntCorpseActions : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;

    public void RemoveCorpse()
    {
        ParticleSystem ep = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        ep.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
