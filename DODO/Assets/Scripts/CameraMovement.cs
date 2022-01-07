using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerpos;
    public float adjust;
    public float distance;

    private void LateUpdate() {

         Vector3 player = new Vector3(transform.position.x, transform.position.y, playerpos.position.z + adjust);
            transform.position = player;
        
    }
}
