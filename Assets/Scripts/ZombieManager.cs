using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{

    NavMeshAgent _agent;
    GameObject _target;
    Animator _animator;
    AudioSource _audioSource;
    Coroutine zombieSound;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
        _audioSource =  gameObject.GetComponent<AudioSource>();
        _animator.SetFloat("Offset", Random.Range(0.0f, 1.0f));
        //int aleatoire = Random.Range(1,100);
        //if (aleatoire >90)
        //{
        //  _audioSource.Play();
        //}
        var zombieTime = Random.Range(1,50);
        StartCoroutine(ZombieMoan(zombieTime));
        
    }

    // Update is called once per frame
    void Update()
    {

        var distance = Vector3.Distance(_target.transform.position, gameObject.transform.position);
        if(distance> 1.5f)
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
    private IEnumerator ZombieMoan(int timer)
    {
        yield return new WaitForSeconds(timer);
        if(!_audioSource.isPlaying)
        {
        _audioSource.Play();
        }
        var zombieTime = Random.Range(1,50);
        StartCoroutine(ZombieMoan(zombieTime));

        

    }
}
