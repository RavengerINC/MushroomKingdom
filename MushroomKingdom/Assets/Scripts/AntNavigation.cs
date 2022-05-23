using UnityEngine;
using UnityEngine.AI;

public class AntNavigation : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject mushroom;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        mushroom = GameObject.Find("HeroMushroom");
    }

    private void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = mushroom.transform.position;
    }
}
