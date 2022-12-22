using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CivilManager : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent _agent;
    GameObject _target;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(_target.transform.position, gameObject.transform.position);
        if(distance< 20f)
        {
            var direction = transform.position - _target.transform.position;
            var newPos = transform.position  + direction;
            _agent.SetDestination(newPos * 10);
        }
    }
}
