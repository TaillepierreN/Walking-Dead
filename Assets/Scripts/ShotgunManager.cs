using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ShotgunManager : MonoBehaviour
{
    bool _isEquipped;
    [SerializeField] Transform _gunHoldPoint; 
    [SerializeField] GameObject _prefabBullet;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] float _force;
    [SerializeField] InputActionReference _shootAction;
    [SerializeField] InputActionReference _reloadAction;
    [SerializeField] TMP_Text _ammoCounter;
    [SerializeField] List<AudioClip> _audioClips;
    AudioSource _audioSource;
    float _ammo;
    // Start is called before the first frame update
    void Start()
    {
        _ammo = 10;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _shootAction.action.Enable();
        _reloadAction.action.Enable();
        _shootAction.action.performed += Shoot;
        _reloadAction.action.performed += Reload;
        if(_isEquipped)
        _ammoCounter.text = "Ammo : " +_ammo;
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        if(_isEquipped && _ammo > 0f)
        {
            GameObject bullet = GameObject.Instantiate(_prefabBullet,_spawnPoint.transform.position, _prefabBullet.transform.rotation);
			bullet.GetComponent<Rigidbody>().AddForce(_spawnPoint.forward * _force, ForceMode.Impulse);
            _ammo = _ammo - 1f;
            _audioSource.clip = _audioClips[1];
            _audioSource.Play();
			Destroy(bullet, 5.0f);
        }

    }
    private void Reload(InputAction.CallbackContext obj)
    {
        _ammo =  10f;
        _audioSource.clip = _audioClips[0];
        _audioSource.Play();
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
