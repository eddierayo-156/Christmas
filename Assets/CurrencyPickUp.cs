using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickUp : MonoBehaviour
{
    public int value = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            LevelManager.instance.IncreaseCurrency(value);
        }
    }
}
