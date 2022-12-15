using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Transform _spawnPoint2;
    [SerializeField] Transform _spawnPoint3;
    [SerializeField] GameManager _gm;
    [SerializeField] GameObject _safe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(gameObject.name == "triggerInside")
        {
            for(int i=0; i < 50; i++)
        {
            _gm.InstiantiateObjectAtSpecificSpawn(_spawnPoint);
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<AudioSource>().Play();
        } else if(gameObject.name == "triggerInside2")
        {
            for(int i=0; i < 50; i++)
        {
            _gm.InstiantiateObjectAtSpecificSpawn(_spawnPoint2);
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
        } else if(gameObject.name == "triggerInside3")
        {
            for(int i=0; i < 100; i++)
        {
            _gm.InstiantiateObjectAtSpecificSpawn(_spawnPoint3);
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (gameObject.name == "Helicopter_01")
        {
            _safe.SetActive(true);
            gameObject.GetComponent<AudioSource>().Play();
            Time.timeScale = 0;
        }
    }
}
