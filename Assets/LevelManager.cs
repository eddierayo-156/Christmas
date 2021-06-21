using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // allows to accessed from anywhere
    public static LevelManager instance;
    
    public Transform respawnPoint;
    public GameObject playerPrefab;
    public CinemachineVirtualCameraBase cameraBase;

    [Header("Currency")]
    public int currency = 0;

    public Text currencyUI;
    
    
    private void Awake()
    {
        // allows access without having to reference
        instance = this;
    }
    
    public void Respawn()
    {
        currency = 0;
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cameraBase.Follow = player.transform;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        currencyUI.text = "$" + currency /*+ " cash moneys"*/;
    }
}
