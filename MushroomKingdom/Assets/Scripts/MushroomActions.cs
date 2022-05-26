using System.Linq;
using UnityEngine;

public class MushroomActions : MonoBehaviour
{
    public void Explode() {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, gameObject.GetComponent<MushroomGrowth>().ExposionRadius);
        
        var ants = hitColliders.Where(hc => hc.gameObject.CompareTag("AntGrunt")).Select(hc => hc.gameObject);

        foreach (var ant in ants)
        {
            ant.GetComponent<AntActions>().KillAnt();
        }

        GameObject.Destroy(gameObject);
    }
}
