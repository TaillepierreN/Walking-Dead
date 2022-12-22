using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    Animator _animator;
    [SerializeField] GameObject _startmenu;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Launch()
    {
        Debug.Log("Launched");
        _startmenu.SetActive(false);
        _animator.SetBool("Launched", true);
    }
    public void EndIntro()
    {
        Destroy(gameObject);
    }
}
