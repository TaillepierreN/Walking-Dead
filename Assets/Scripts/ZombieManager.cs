using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{

    NavMeshAgent _agent;
    [SerializeField] Transform _spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_spawnpoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
