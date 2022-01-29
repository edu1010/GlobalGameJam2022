using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public LayerMask WhatIsVisible;
    private GameObject _player;

    public float range = 3f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //onbecome visible, when true check distance, inf distance < than smth then shader, press a button, blur the background 
    //distance activates the outline (if there's only onbe obj). If its visible, create a ray towards the player and check the angle
    //if you are looking directly at the object then the outline activates, if not it satys the way it was
    //condition checkangle which is always true (vector3.Dot)
    //empty game object child of pitch and spawn the object there
    //spherecast or angle between forward and actual direction

    private void CheckDistance()
    {
        float dist = Vector3.Distance(_player.transform.position, this.transform.position);
        Debug.Log(dist);
        if (dist <= range)
        {
            //activate outline
            if(CheckAngle())
            {
                
            }

        }
            
    }

    private bool CheckAngle()
    {
        //comprobar angulo
        RaycastHit2D checkAng = Physics2D.Raycast(this.transform.position, Vector3.forward, range, WhatIsVisible);
        return true;
    }

    private void OnBecameVisible()
    {
        CheckDistance();
        Debug.Log("visible");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
    }
}
