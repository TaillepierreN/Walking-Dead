using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{

    NavMeshAgent _agent;
    GameObject _target;
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        var distance = Vector3.Distance(_target.transform.position, gameObject.transform.position);
        if(distance> 1.0f)
        {
        _agent.SetDestination(_target.transform.position);
        _animator.SetBool("IsAttacking",false);
        _agent.isStopped = false;


        }
        else{

        _agent.isStopped = true;
        _animator.SetBool("IsAttacking",true);
        }

        
    }
}
