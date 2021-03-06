using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("PowerUp & HealthUp")]
    [SerializeField] GameObject bigLaserPrefab;
    [SerializeField] GameObject cannonLaserPrefab;
    [SerializeField] AudioClip powerUpSFX;
    [SerializeField] AudioClip laserPowerUpSFX;
    [SerializeField] float fireRateUpgradeAmount = 0.05f;
    [SerializeField] float moveSpeedBoostAmount = 0.05f;
    [SerializeField] int healthBoostAmount = 20;

    [Header("Player Control")]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float leftPadding;
    [SerializeField] float rightPadding;
    [SerializeField] float topPadding;
    [SerializeField] float bottomPadding;

    bool isBigLaserActive = false;
    bool isCannonLaserActive = false;


    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;
    Health health;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
    }

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }


    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + bottomPadding, maxBounds.y - topPadding);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            UpgradeLaser();
            BoostFireRate();
            BoostSpeed();
            AudioSource.PlayClipAtPoint(powerUpSFX, Camera.main.transform.position);
            Destroy(other.gameObject);
        }

        if (other.tag == "HealthUp")
        {
            AudioSource.PlayClipAtPoint(powerUpSFX, Camera.main.transform.position);
            BoostHealth();
            Destroy(other.gameObject);
        }
    }

    void BoostFireRate()
    {
        if (shooter != null)
        {
            shooter.baseFireRate -= fireRateUpgradeAmount;
            shooter.baseFireRate = Mathf.Clamp(shooter.baseFireRate, 0.0001f, float.MaxValue);
        }
    }

    void BoostSpeed()
    {
        moveSpeed += moveSpeedBoostAmount;
        moveSpeed = Mathf.Clamp(moveSpeed, 1f, 10f);
    }

    void BoostHealth()
    {
        health.IncreaseHealth(healthBoostAmount);
    }

    void UpgradeLaser()
    {
        if (shooter != null)
        {
            float x = shooter.baseFireRate;
            if (0.19f <= x && x <= 0.24f)
            {
                if (!isBigLaserActive)
                {
                    AudioSource.PlayClipAtPoint(laserPowerUpSFX, Camera.main.transform.position);
                    isBigLaserActive = true;
                }
                shooter.projectilePrefab = bigLaserPrefab;
            }
            else if (x < 0.19f)
            {
                if (!isCannonLaserActive)
                {
                    AudioSource.PlayClipAtPoint(laserPowerUpSFX, Camera.main.transform.position);
                    isCannonLaserActive = true;
                }
                shooter.projectilePrefab = cannonLaserPrefab;
            }
        }
    }


}
