// powerupspawner

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public static PowerupSpawner Instance;

    public GameObject[] powerups;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject SpawnPowerup()
    {
        int randomIndex = Random.Range(0, powerups.Length);
        return Instantiate(powerups[randomIndex], transform.position, Quaternion.identity);
    }
}