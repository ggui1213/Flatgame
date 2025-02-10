using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    // The AudioClip for the audio effect to play over the BGM.
    public AudioClip audioEffectClip;

    // Optional: Only trigger once.
    private bool hasTriggered = false;

    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.isTrigger = true;
            boxCollider.includeLayers = int.MaxValue;
        }
        else
        {
            Debug.LogWarning("No BoxCollider2D found on " + gameObject.name);
        }

        // Add an AudioSource component if one is not already attached.
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug print to confirm the trigger is being entered.
        Debug.Log("Effect trigger entered by: " + collision.gameObject.name);

        if (!hasTriggered && collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(audioEffectClip);
            hasTriggered = true;
        }
    }
}