using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Zombie")]
    [Tooltip("Préfab de zombie")]
    [SerializeField] GameObject _prefabzombie;
    [Space(10)]
    [SerializeField] Transform _spawnPoint;
    [SerializeField] List<Transform> _spawnPoints;
    [SerializeField] int _nombreDeZombie;
    [SerializeField] GameObject player;
    [SerializeField] InputActionReference _actionSpawnZombies;
    // Start is called before the first frame update
    void Start()
    {
        _actionSpawnZombies.action.Enable();
        _actionSpawnZombies.action.performed += OnSpawnZombie;        //InstantiateXObjectsRandomly();
        InstiantiateObjectAtStart();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     InstantiateXObjectsRandomly();
        // }
    }
    public void InstiantiateObject()
    {
        GameObject.Instantiate(_prefabzombie);
    }
    public void InstiantiateObjectAtStart()
    {
        for(int i=0; i < _nombreDeZombie; i++)
        {
            GameObject.Instantiate(_prefabzombie, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
    public void InstiantiateObjectAtSpawn()
    {
        GameObject.Instantiate(_prefabzombie, _spawnPoint.position, _spawnPoint.rotation);
    }
        public void InstiantiateObjectAtSpecificSpawn(Transform spawn)
    {
        GameObject.Instantiate(_prefabzombie, spawn.position, spawn.rotation);
    }
        public void InstiantiateObjectAtPosition(int x, int z)
    {
        var zombie = GameObject.Instantiate(_prefabzombie, new Vector3(x, 0.049f, z), Quaternion.identity);
        zombie.transform.LookAt(Camera.main.transform);
    }
    public void InstantiateXObjectsRandomly()
    {

        for(int i=0; i < _nombreDeZombie; i++)
        {
            InstiantiateObjectAtPosition(Random.Range(-49,50),Random.Range(-49,50));
        }
        
    }
    public void GuyOuInstantiateXObjectsAtRandomSpawnPoint()
    {
        for(int i = 0; i < _nombreDeZombie; i++)
        {
        int aleatoire;
        aleatoire = Random.Range(0,_spawnPoints.Count);
        _spawnPoint = _spawnPoints[aleatoire];      
        }
        InstiantiateObjectAtSpawn();

    }
    public void OnSpawnZombie(InputAction.CallbackContext obj)
 	{
        GuyOuInstantiateXObjectsAtRandomSpawnPoint();
  	}

}
