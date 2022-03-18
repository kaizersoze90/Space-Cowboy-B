using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    public float baseFireRate = 0.2f;
    public GameObject projectilePrefab;


    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float fireRateVariance = 0.2f;
    [SerializeField] float minFireRate = 0.1f;

    [HideInInspector] public bool isFiring;

    Coroutine fireCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            audioPlayer.PlayShootingSFX();
            float fireRate = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            fireRate = Mathf.Clamp(fireRate, minFireRate, float.MaxValue);
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
