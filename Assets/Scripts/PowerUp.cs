using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Ship Power Up")]
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] float powerUpSpawnChance = 1f;
    [SerializeField] float powerUpDestroyDelay = 5f;
    [SerializeField] float powerUpFallDownSpeed = 1.5f;

    [Header("Health Power Up")]
    [SerializeField] GameObject healthUpPrefab;
    [SerializeField] float healthUpSpawnChance = 1f;
    [SerializeField] float healthUpDestroyDelay = 5f;
    [SerializeField] float healthUpFallDownSpeed = 1.5f;


    public void SpawnPowerUp(Vector3 pos)
    {
        float spawnRate = Random.Range(0f, 2f);
        if ((spawnRate * powerUpSpawnChance) > 1)
        {
            GameObject powerupGO = Instantiate(powerUpPrefab, pos, Quaternion.identity);
            Rigidbody2D rb = powerupGO.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * powerUpFallDownSpeed;
            Destroy(powerupGO, powerUpDestroyDelay);
        }
    }

    public void SpawnHealthUp(Vector3 pos)
    {
        float spawnRate = Random.Range(0f, 2f);
        if ((spawnRate * healthUpSpawnChance) > 1)
        {
            GameObject healthUpGO = Instantiate(healthUpPrefab, pos, Quaternion.identity);
            Rigidbody2D rb = healthUpGO.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * healthUpFallDownSpeed;
            Destroy(healthUpGO, healthUpDestroyDelay);
        }
    }
}
