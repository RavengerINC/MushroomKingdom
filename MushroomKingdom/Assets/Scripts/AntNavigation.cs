using UnityEngine;
using UnityEngine.AI;

public class AntNavigation : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject mushroom;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        mushroom = GameObject.Find("HeroMushroom");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = mushroom.transform.position;
    }
}
