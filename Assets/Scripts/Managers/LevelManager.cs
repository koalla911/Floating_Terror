using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private RobotCharacter playableCharacter;
    [SerializeField] private Transform spawnPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
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

    }
}
