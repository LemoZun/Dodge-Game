using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearzoneTrigger : MonoBehaviour
{

    public event Action OnGameCleared;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Å¬¸®¾î");
            Manager.Game.GameClear();
        }

        
    }
}
