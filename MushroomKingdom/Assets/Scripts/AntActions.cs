using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AntActions : MonoBehaviour
{
    [SerializeField] private GameObject deadAntPrefab;
    [SerializeField] private ParticleSystem explosionParticles;

    public UnityEvent AntKilledEvent;

    public void Start() {
        if(AntKilledEvent == null) {
            AntKilledEvent = new UnityEvent();
        }
    }

    public void KillAnt() {
        ParticleSystem ep = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        ep.GetComponent<ParticleSystem>().Play();
        Instantiate(deadAntPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        AntKilledEvent.Invoke();
    }
}
