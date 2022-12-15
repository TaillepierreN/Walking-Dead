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
    [SerializeField] int _nombreDeZombie;
    private StarterAssetsInputs _input;
    private PlayerInput _playerInput;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateXObjectsRandomly();
        _input = GetComponent<StarterAssetsInputs>();
        _playerInput = GetComponent<PlayerInput>();   
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
    public void InstiantiateObjectAtSpawn()
    {
        GameObject.Instantiate(_prefabzombie, _spawnPoint.position, _spawnPoint.rotation);
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
    public void OnSpawnZombie()
 	{
        InstantiateXObjectsRandomly();
  	}

}
