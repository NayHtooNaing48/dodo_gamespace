using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    [Range(0f, 8f)]
    private float firerate;

    private float timer;


    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= firerate)
        {
            if (Vector3.Distance(transform.position, player.position) < 15f)
            {
                timer = 0f;
                weaponShoot();
                Debug.Log(Vector3.Distance(transform.position, player.position));
                
            }
            




        }




    }
    private void weaponShoot()
    {
        GameObject vfx = Instantiate(fireball, firepoint.position, Quaternion.identity);
        vfx.transform.localRotation = Quaternion.LookRotation(firepoint.forward);
        
    }



}
