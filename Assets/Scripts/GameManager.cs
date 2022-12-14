using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _prefabzombie;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] int _nombreDeZombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
