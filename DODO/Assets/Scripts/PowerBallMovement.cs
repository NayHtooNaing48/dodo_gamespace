using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBallMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage =1;
    [SerializeField]
    private GameObject muzzleVfx;
    [SerializeField]
    private GameObject hitVfx;
    [SerializeField]
    private float distance;


    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
        GameObject vfx = Instantiate(muzzleVfx,transform.position,Quaternion.identity);
        vfx.transform.forward = transform.forward;
        Destroy(vfx,1f);
    }

    private void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position,startPos) >= distance)
            {
                 Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        speed = 0;
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        GameObject vfx = Instantiate(hitVfx, pos, rot);
        Destroy(vfx, 1f);
        var health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.takeDamage(damage);
            Debug.Log(col.gameObject.name);
        }
        
       
            Destroy(gameObject);
        
    }
}
