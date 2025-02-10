using System;
using UnityEngine;

public class BGMTrigger : MonoBehaviour
{
    // The new AudioClip to switch to.
    public AudioClip newBGMClip;

    // Optional: Only trigger once.
    private bool hasSwitched = false;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().includeLayers = int.MaxValue;
        if (!GetComponent<AudioSource>())
            gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("fuck");
        if (!hasSwitched && collision.CompareTag("Player"))
        {
            // Use the AudioManager singleton to switch the BGM.
            var source = GetComponent<AudioSource>();
            AudioManager.instance.SwitchBGM(source, newBGMClip);

            hasSwitched = true;
        }
    }
}