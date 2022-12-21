using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Grab : MonoBehaviour
{
    [SerializeField] float _rayLength;
    [SerializeField] InputActionReference _actionGrab;
    [SerializeField] float _snapForce;
    [SerializeField] Transform _holdPosition;
    private Rigidbody _grabbedObject;
    private bool isGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        //_actionGrab.action.Enable();
       // _actionGrab.action.performed += Grabbing;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_grabbedObject)
        {
            //_grabbedObject.AddForce((transform.GetChild(0).position - _grabbedObject.transform.position) * _snapForce, ForceMode.Impulse);
            _grabbedObject.velocity = (_holdPosition.position - _grabbedObject.transform.position) * _snapForce;
        } 
    }
    private void OnGrab()
    {
        if(!isGrabbed)
        {
            ShootRaycast();
            isGrabbed = true;
            if(_grabbedObject)
            {
                _grabbedObject.transform.parent = transform;
            }
        }
        else{
            if(_grabbedObject)
            {
                DropDraggedObject();

            }
            isGrabbed = false;
        }
        
    }

    private void DropDraggedObject()
    {
        _grabbedObject.transform.parent = null;
        _grabbedObject = null;
    }

    private void OnThrowGrabbed()
    {
        if(_grabbedObject)
        {
            _grabbedObject.AddForce(Camera.main.transform.forward * _snapForce, ForceMode.Impulse);
            DropDraggedObject();
        }
    }

    private void ShootRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hit, _rayLength))
        {
            if (hit.transform.CompareTag("Grabbable"))
            {
                _grabbedObject = hit.rigidbody;
                //hit.rigidbody.AddForce((transform.GetChild(0).position - hit.transform.position) * _snapForce, ForceMode.Impulse);
                //   hit.rigidbody.velocity = hit.transform.position - transform.position;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.GetChild(0).position, transform.GetChild(0).forward * _rayLength);
    }

    // public void Grabbing(InputAction.CallbackContext obj)
    // {
    //      RaycastHit hit;
    //     if(Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward , out hit,_rayLength))
    //     {
    //         if(hit.transform.CompareTag("Grabbable"))
    //         {
    //             hit.rigidbody.useGravity = false;
    //             hit.rigidbody.velocity = (transform.GetChild(0).position - hit.transform.position);
    //         }
    //     }
    // }

}
