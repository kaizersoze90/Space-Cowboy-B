using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damaged")]
    [SerializeField] AudioClip damagedClip;
    [SerializeField][Range(0f, 1f)] float damagedVolume = 1f;

    public void PlayShootingSFX()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayDamagedSFX()
    {
        if (damagedClip != null)
        {
            AudioSource.PlayClipAtPoint(damagedClip, Camera.main.transform.position, damagedVolume);
        }
    }

}
