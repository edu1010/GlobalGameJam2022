using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public LayerMask WhatIsVisible;
    private GameObject _playerObj;
    private Player _player;

    public float range;
    private bool pressed = false;
    private bool visible = false;
    private bool interactable = false;
    // Start is called before the first frame update
    void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _player = _playerObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.Pressed)
        {
            //Debug.Log("interact");
            pressed = !pressed;
        }
        if(visible)
        {
            CheckDistance();
            CheckAngle();
        }
        if (pressed)
        {
            Interaction();
        }
    }

    //onbecome visible, when true check distance, inf distance < than smth then shader, press a button, blur the background 
    //distance activates the outline (if there's only onbe obj). If its visible, create a ray towards the player and check the angle
    //if you are looking directly at the object then the outline activates, if not it satys the way it was
    //condition checkangle which is always true (vector3.Dot)
    //empty game object child of pitch and spawn the object there
    //spherecast or angle between forward and actual direction

    private void CheckDistance()
    {
        float dist = Vector3.Distance(_playerObj.transform.position, this.transform.position);
        //Debug.Log(dist);
        if (dist <= range)
        {
            //activate outline
            interactable = true;
        }
            
    }

    private bool CheckAngle()
    {
        //comprobar angulo
        //RaycastHit2D checkAng = Physics2D.Raycast(this.transform.position, Vector3.forward, range, WhatIsVisible);
        //RaycastHit2D checkPlayerAng = Physics2D.Raycast(_playerObj.transform.position, Vector3.forward, range, WhatIsVisible);
        float checkedVector = Vector3.Dot(_playerObj.transform.forward, transform.forward);
        //Debug.Log(checkedVector);
        if (checkedVector > 0.5)
            return true;
        else
            return false;
    }

    private void OnBecameVisible()
    {
        visible = true;
        //Debug.Log("visible");
    }

    private void OnBecameInvisible()
    {
        visible = false;
        interactable = false;
        pressed = false;
        //Debug.Log("Invisible");
    }

    public void Interaction()
    {
        //method for interaction with objects if necessary idk
        if (interactable)
        {
            if (pressed)
            {
                Debug.Log("interact");
            }
        }
    }
}
