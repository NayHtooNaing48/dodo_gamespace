using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Camera camera;

    private void Awake()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y+1.5f, target.position.z);
        var targetPos = camera.WorldToScreenPoint(pos);
        transform.position = targetPos;
    }
}
