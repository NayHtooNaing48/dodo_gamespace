using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickAvanced : MonoBehaviour
{
    [SerializeField]
    private Transform joystickRight;
    [SerializeField]
    private Transform joystickLeft;

    private Vector2 currentRight;
    private Vector2 oldposRight;
    private Vector2 currentLeft;
    private Vector2 oldposLeft;

    private void Awake()
    {
        oldposRight = joystickRight.position;
        oldposLeft = joystickLeft.position;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //if (Input.mousePosition.magnitude)
            //Debug.Log((Input.mousePosition.x / 1000 > 0.5f) ? "right" : "left");
            //Debug.Log(Input.mousePosition.y/720);
            if (Input.mousePosition.x / 1000 > 0.7f && Input.mousePosition.y / 720 < 0.65)
            {
                currentRight = Input.mousePosition;
            }
            

        }
    
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
            //Debug.Log(Input.mousePosition.x/1000);
            //if (Input.mousePosition.x / 1000 > 0.5f && Input.mousePosition.y / 720 < 0.65)
            //{
            
                currentRight = oldposRight;
            

        }
        if (currentRight != Vector2.zero ) {
                joystickRight.position = currentRight;

        }
        

    }

        
}
