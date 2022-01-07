using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Transform dodo;
    [SerializeField]
    private float rotatespeed;
    [SerializeField]
    private joystick joystick_move;
    [SerializeField]
    private Weapons weapons;
    [SerializeField]
    private Transform firepoint;

    private Vector3 velocity;
    private Rigidbody myRigi;
    private void Awake()
    {
        myRigi = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        
        
        
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        if (Application.platform == RuntimePlatform.Android) {
             z = joystick_move.InputDirection.z;
             x = joystick_move.InputDirection.x;
        }

        var movement = new Vector3(x, 0, z);
        
        velocity = new Vector3(x*speed, gameObject.GetComponent<Rigidbody>().velocity.y,z*speed);
        transform.localEulerAngles = new Vector3(z * 20f,transform.localEulerAngles.y,-x*20f);
        //firepoint.localEulerAngles = new Vector3(-z * 20f, firepoint.localEulerAngles.y, -x * 20f);
        playerAnimator.SetFloat("speed", movement.magnitude);
        if (movement.magnitude > 0 && weapons.movement.magnitude == 0f)
        {
            Quaternion direction = Quaternion.LookRotation(movement);
            dodo.rotation = Quaternion.Slerp(dodo.rotation,direction,rotatespeed*Time.deltaTime);
            dodo.localEulerAngles = new Vector3(0,dodo.localEulerAngles.y,0);
        }
    }
    private void FixedUpdate()
    {
        myRigi.velocity = velocity;
    }
}
