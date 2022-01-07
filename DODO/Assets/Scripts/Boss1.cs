using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private Transform[] firepoint;
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    [Range(0f, 1.5f)]
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
                    gameObject.transform.LookAt(player);
                    Debug.Log(Vector3.Distance(transform.position, player.position));
                    healthBar.SetActive(true);
                }
                else
                {
                    healthBar.SetActive(false);
                }
               



            }
        
       
        

    }
    private void weaponShoot()
    {
        GameObject vfx = Instantiate(fireball, firepoint[0].position, Quaternion.identity);
        vfx.transform.localRotation = Quaternion.LookRotation(firepoint[0].forward);
        GameObject vfx1 = Instantiate(fireball, firepoint[1].position, Quaternion.identity);
        vfx1.transform.localRotation = Quaternion.LookRotation(firepoint[1].forward);
        GameObject vfx2 = Instantiate(fireball, firepoint[2].position, Quaternion.identity);
        vfx2.transform.localRotation = Quaternion.LookRotation(firepoint[2].forward);
    }

}
