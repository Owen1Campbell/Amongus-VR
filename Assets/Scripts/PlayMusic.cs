using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip song;
    public AudioSource src;
    void PlayClip() {
        src.clip = song;
        src.Play();
    }
}
