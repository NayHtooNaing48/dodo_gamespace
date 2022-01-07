using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss3Lavaq : MonoBehaviour
{
    [SerializeField]
    private GameObject hitVfx;

    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    

    private void Update()
    {
        
        if (player != null)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.position);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        GameObject vfx = Instantiate(hitVfx, pos, rot);
        Destroy(vfx, 1f);
        var health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {

            health.takeDamage(5);
            Debug.Log(col.gameObject.name);

            
            if (col.gameObject.CompareTag("dodo"))
            {
                Destroy(gameObject);
            }
        }

        
    }
}
