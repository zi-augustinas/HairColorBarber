using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpraySoundController : MonoBehaviour
{
    AudioSource m_AudioSource;
    [SerializeField]
    AudioClip m_PickupSound;
    [SerializeField]
    AudioClip m_SpraySound;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySpraySound()
    {
        m_AudioSource.loop = true;
        m_AudioSource.clip=m_SpraySound;
        m_AudioSource.Play();
    }

    public void PlayPickUpSound()
    {
        m_AudioSource.loop = false;
        m_AudioSource.clip=m_PickupSound;
        m_AudioSource.Play();
    }

    public void StopSpraySound()
    {
        m_AudioSource.Stop();
    }


}
