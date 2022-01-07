using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1.5f)]
    private float firerate = 0.3f;
    [SerializeField]
    [Range(1,10)]
    private int damage = 1;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private ParticleSystem mf;
    [SerializeField]
    private AudioSource gun_sound;
    [SerializeField]
    private joystick joystick_shoot;
    [SerializeField]
    private Transform dodo;
    [SerializeField]
    private float rotatespeed;
    [SerializeField]
    [Range(10,100)]
    private float ray_distance= 10;
    [SerializeField]
    private Slider power_bar;
    [SerializeField]
    private GameObject powerball;
    [SerializeField]
    private Transform dodo_hand;
    
    private float timer;
    public Vector3 movement { set; get; }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firerate && power_bar.value > 1)
        {
            if (joystick_shoot.InputDirection.magnitude > 0)
            {
                timer = 0f;
                weaponShoot();
            }


        }
        

        movement = new Vector3(joystick_shoot.InputDirection.x, 0, joystick_shoot.InputDirection.z);
        if (movement.magnitude > 0)
        {
            Quaternion direction = Quaternion.LookRotation(movement);
            dodo.rotation = Quaternion.Slerp(dodo.rotation, direction, rotatespeed * Time.deltaTime);
            //dodo.localEulerAngles = new Vector3(0, dodo.localEulerAngles.y, 0);
            

        }
        else if (power_bar.value != power_bar.maxValue)
        {
            power_bar.value += Time.deltaTime * 6;
        }
        dodo_hand.localEulerAngles = new Vector3(-90 * movement.magnitude, 0, 0);


    }
    private void weaponShoot() {
        Debug.DrawRay(firepoint.position, firepoint.forward* ray_distance, Color.red, 2f);
        //mf.Play();
        GameObject vfx = Instantiate(powerball, firepoint.position, Quaternion.identity);
        vfx.transform.localRotation = Quaternion.LookRotation(firepoint.forward);
        gun_sound.Play();
        power_bar.value--;
        /*Ray fire = new Ray(vfx.transform.position, vfx.transform.forward);
        RaycastHit hitinfo;
        if (Physics.Raycast(fire,out hitinfo,ray_distance)) {
            var health = hitinfo.collider.GetComponent<Health>();
            if (health != null) {
                health.takeDamage(damage);
            }
        }*/


    }
}
