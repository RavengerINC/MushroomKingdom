using UnityEngine;

public class AntActions : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 10;
    [SerializeField] private GameObject deadAntPrefab;
    [SerializeField] private ParticleSystem explosionParticles;

    public void KillAnt() {
        ParticleSystem ep = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        ep.GetComponent<ParticleSystem>().Play();
        Instantiate(deadAntPrefab, transform.position, Quaternion.identity);
        ScoreTracker.Instance.IncrementScore(scoreAmount);
        Destroy(gameObject);
    }

    public void RemoveAnt()
    {
        Destroy(gameObject);
    }
}
