using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    void OnEnable()
    {
        EventManager.MousePressEvent += PlayClipFx;
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= PlayClipFx;
    }
   
    void PlayClipFx()
    {
        audioSource.PlayOneShot(audioClip, 0.5f);
    }
}
