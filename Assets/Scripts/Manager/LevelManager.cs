using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Character playableCharacter;
    [SerializeField] private Transform spawnPosition; // SerialiField for playableCharacter and spawnPosition //

    // Update is called once per frame
    private void Update()
    {
        //We need a position for the character to spawn again in the game scene. So we create an input key to revive the character. When we press the key the character will appear again at new location (spawn location). Here we need to declare the input key and call the ReviveCharacter. 
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReviveCharacter();
        }
    }

    private void ReviveCharacter()
    {
        if (playableCharacter.GetComponent<Health>().CurrentHealth <= 0)
        {
            playableCharacter.GetComponent<Health>().Revive();
            playableCharacter.transform.position = spawnPosition.position;
        }
        // Here we need to get the component of health and set the spawn position//
    }
}

