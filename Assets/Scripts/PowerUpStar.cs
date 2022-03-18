using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStar : MonoBehaviour
{
    [SerializeField] float fallSpeed = 1.5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Vector2.down * fallSpeed;
    }
}
