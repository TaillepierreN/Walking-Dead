using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{

    Animator _animator;
    AudioSource _audioSource;
    Coroutine zombieSound;
    GameObject _target;
    NavMeshAgent _agent;
    [SerializeField] GameObject _ragdollPrefab;
    [SerializeField] List<AudioClip> _audioClips;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Civilian");
        _animator = GetComponent<Animator>();
        _audioSource =  gameObject.GetComponent<AudioSource>();
        _audioSource.clip = _audioClips[Random.Range(0,_audioClips.Count-1)];
        _animator.SetFloat("Offset", Random.Range(0.0f, 1.0f));
        //int aleatoire = Random.Range(1,100);
        //if (aleatoire >90)
        //{
        //  _audioSource.Play();
        //}
        var zombieTime = Random.Range(1,30);
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
        var zombieTime = Random.Range(1,30);
        StartCoroutine(ZombieMoan(zombieTime));

        

    }
    private void OnCollisionEnter(Collision other) {

        if(other.collider.CompareTag("Grabbable"))
        {
            Instantiate(_ragdollPrefab, transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
