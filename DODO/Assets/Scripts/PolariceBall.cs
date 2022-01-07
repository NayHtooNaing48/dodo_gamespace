using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PolariceBall : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject muzzleVfx;
    [SerializeField]
    private GameObject hitVfx;
    [SerializeField]
    private float distance;
    
    private Transform firepoint;


    private Vector3 startPos;
    private void Start()
    {
        firepoint = GameObject.Find("firepointPolar").transform;
        startPos = transform.position;
        GameObject vfx = Instantiate(muzzleVfx, transform.position, Quaternion.identity);
        vfx.transform.forward = transform.forward;
        Destroy(vfx, 1f);
    }

    private void Update()
    {
        if (speed != 0)
        {
            transform.position += firepoint.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, startPos) >= distance)
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
        var movement = col.gameObject.GetComponent<NavMeshAgent>();
        if (health != null && movement != null)
        {
            
            health.takeDamage(damage);
            Debug.Log(col.gameObject.name);

            movement.speed = 1.5f ;

        }
       
            Destroy(gameObject);

        
        
    }
}
