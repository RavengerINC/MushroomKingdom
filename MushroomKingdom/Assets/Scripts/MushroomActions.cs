using System.Linq;
using UnityEngine;

public class MushroomActions : MonoBehaviour
{
    [SerializeField] private GameObject explosionParticles;

    public void Explode() {
        float explosionRadius = gameObject.GetComponent<MushroomGrowth>().ExposionRadius;

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, explosionRadius);
        
        var ants = hitColliders.Where(hc => hc.gameObject.CompareTag("AntGrunt")).Select(hc => hc.gameObject);

        GameObject ps = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        ps.transform.localScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);
        ps.GetComponentInChildren<ParticleSystem>().Play();

        foreach (var ant in ants)
        {
            ant.GetComponent<AntActions>().KillAnt();
        }

        Destroy(gameObject);
    }
}
