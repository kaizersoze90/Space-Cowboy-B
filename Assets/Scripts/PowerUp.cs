using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] float spawnChance = 1f;
    [SerializeField] float powerUpDestroyDelay = 5f;
    [SerializeField] float powerUpFallDownSpeed = 1.5f;


    public void SpawnPowerUp(Vector3 pos)
    {
        float spawnRate = Random.Range(0f, 2f);
        if ((spawnRate * spawnChance) > 1)
        {
            GameObject powerupGO = Instantiate(powerUpPrefab, pos, Quaternion.identity);
            Rigidbody2D rb = powerupGO.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * powerUpFallDownSpeed;
            Destroy(powerupGO, powerUpDestroyDelay);
        }
    }
}
