using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunManager : MonoBehaviour
{
    bool _isEquipped;
    [SerializeField] Transform _gunHoldPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _isEquipped = true;
            transform.position = _gunHoldPoint.position;
            transform.rotation = _gunHoldPoint.rotation;
            transform.parent = _gunHoldPoint;
        }

    }
}
