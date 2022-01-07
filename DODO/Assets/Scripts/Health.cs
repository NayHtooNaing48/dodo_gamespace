using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int starting_health;
    [SerializeField]
    private Slider health_bar;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject inicator_org;
    [SerializeField]
    private Transform indicator_trans;

    public int current_health;
    

    private void OnEnable()
    {
        current_health = starting_health;
    }
    public void takeDamage(int damage) {
        current_health -= damage;
        health_bar.value = current_health;
        Debug.Log(current_health);
        if (gameObject.CompareTag("dodo"))
        {
            GameObject indicator = Instantiate<GameObject>(inicator_org, indicator_trans);
            Destroy(indicator, 0.5f);
        }
            if (current_health <= 0) {
            
            Die();
        }

    }

    private void Die()
    {
        if (gameObject.CompareTag("dodo"))
        {
            gameObject.SetActive(false);
            losePanel.SetActive(true);
            GameObject indicator = Instantiate<GameObject>(inicator_org, indicator_trans);
            Destroy(indicator, 1f);
            Time.timeScale = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
