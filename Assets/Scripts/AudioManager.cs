using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    // The AudioSource that plays the BGM.
    public AudioSource bgmSource;

    private void Awake()
    {
        // Singleton pattern: if an instance doesn't exist, set it and persist.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to switch the background music.
    public void SwitchBGM(AudioSource newSource,AudioClip newClip)
    {
        if (bgmSource.isPlaying)
            bgmSource.Stop();
        bgmSource = newSource;

        bgmSource.clip = newClip;
        bgmSource.Play();
    }
}