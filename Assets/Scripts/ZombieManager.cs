using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{

    NavMeshAgent _agent;
    GameObject _target;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        _agent.SetDestination(_target.transform.position);
        
    }
}
