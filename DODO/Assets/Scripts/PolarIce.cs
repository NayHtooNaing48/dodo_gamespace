using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PolarIce : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject polariceball;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    [Range(0f, 1.5f)]
    private float firerate;
    [SerializeField]
    private Vector3 frontSensorPosition = new Vector3(0f, 2f, 0f);
    [SerializeField]
    private float sensorlength = 100f;
    [SerializeField]
    private float sideAngleposition;
    [SerializeField]
    private GameObject losePanel;
    private GameObject enemy;
    private float timer;
    private bool avoiding;
    

    private void Awake()
    {
        
    }
    void Update()
    {

            timer += Time.deltaTime;
            if (timer >= firerate)
            {
                if (Sensor())
                {

                    timer = 0f;
                    weaponShoot();
                }


            }

        if (player.gameObject != null)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.position);
        }
        else {
            losePanel.SetActive(true);

        }
        if (enemy != null) {

            transform.LookAt(enemy.transform);

        }
        
    }
    private bool Sensor()
    {
        RaycastHit hit;
        avoiding = false;
        Vector3 StartpointSensor = transform.position;
        StartpointSensor += transform.forward * frontSensorPosition.x;
        StartpointSensor += transform.up * frontSensorPosition.y;

        
        StartpointSensor += transform.right * frontSensorPosition.z;
        //center
        for (int i = 0; i < 10; i++)
        {
            if (Physics.Raycast(StartpointSensor, Quaternion.AngleAxis(sideAngleposition+(36f*i), transform.up) * transform.forward, out hit, sensorlength))
            {
                Debug.DrawLine(StartpointSensor, hit.point);
                if (hit.collider.CompareTag("enemy"))
                {
                    Debug.DrawLine(StartpointSensor, hit.point);
                    avoiding = true;
                    enemy = hit.collider.gameObject;
                }
            }
        }
        
        

        return avoiding;

    }
    private void weaponShoot()
    {
        GameObject vfx = Instantiate(polariceball, firepoint.position, Quaternion.identity);
        vfx.transform.localRotation = Quaternion.LookRotation(firepoint.forward);
    }
}
