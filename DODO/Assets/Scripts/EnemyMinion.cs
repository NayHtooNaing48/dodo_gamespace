using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMinion : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private Vector3 frontSensorPosition = new Vector3(0f, 2f, 0f);
    [SerializeField]
    private float sensorlength = 100f;
    [SerializeField]
    [Range(0f, 1.5f)]
    private float firerate;
    

    private float timer;
    private bool avoiding;
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Sensor())
        {
            //Debug.Log("shoot");


            if (timer >= firerate)
            {

                timer = 0f;
                weaponShoot();



            }
        }
        else {
            //Debug.Log("can't shoot");
        }
        if (Vector3.Distance(transform.position,player.position) < 15f)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.position);
            gameObject.transform.LookAt(player);
            Debug.Log(Vector3.Distance(transform.position, player.position));
        }
        
    }

    private bool Sensor()
    {
        RaycastHit hit;
        avoiding = false;
        Vector3 StartpointSensor = transform.position;
        StartpointSensor += transform.forward * frontSensorPosition.x;
        StartpointSensor += transform.up * frontSensorPosition.y;

        //right
        StartpointSensor += transform.right * frontSensorPosition.z;
        
        if (Physics.Raycast(StartpointSensor, transform.forward, out hit, sensorlength))
        {

            if (hit.collider.CompareTag("dodo"))
            {
                Debug.DrawLine(StartpointSensor, hit.point);
                avoiding = true;

            }
            
        }
        return avoiding;

    }

    private void weaponShoot()
    {
        GameObject vfx = Instantiate(fireball, firepoint.position, Quaternion.identity);
        vfx.transform.localRotation = Quaternion.LookRotation(firepoint.forward);
    }
    
}
