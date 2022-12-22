using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CivilManager : MonoBehaviour
{
    // Start is called before the first frame update
    Animator _animator;
    AudioSource _audioSource;
    GameObject _target;
    NavMeshAgent _agent;
    [SerializeField] Transform _destination;
    [SerializeField] List<AudioClip> _civSounds;
    private Transform _player;
    private Transform _enemy;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource =  gameObject.GetComponent<AudioSource>();
        _player = GameObject.FindWithTag("Player").transform;
        _enemy = GameObject.FindWithTag("Zombie").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, _enemy.transform.position);
         // Debug.Log(Convert.ToInt32(distance * 10) / 10);
          if(distance < 2.5f)
          {
          GoToDestination();
          ChangeAudioClip(1);
          _animator.SetBool("isRunning", true);

          } else if( distance < 4.0f ) {
             ChangeAudioClip(2);
          }
          else{
             ChangeAudioClip(0);
             StopFleeing();
             _animator.SetBool("isRunning", false);

         }
         GererLAudio();
    }
    private void ChangeAudioClip(int index)
    {
         if(!_audioSource.isPlaying || _audioSource.clip == _civSounds[0])
         _audioSource.clip = _civSounds[index];
    }
    private void StopFleeing()
    {
        _agent.isStopped= true;
    }

    private void GoToDestination()
    {
        _destination.position = transform.position + (transform.position - _enemy.position);
        _agent.SetDestination(_destination.position);
        _agent.isStopped= false;
    }

    private void GererLAudio()
    {
        int rand;
       rand = UnityEngine.Random.Range(1,5);
       if(rand == 2 && ! _audioSource.isPlaying)
       {
        _audioSource.Play();
       }
        
    }
}
