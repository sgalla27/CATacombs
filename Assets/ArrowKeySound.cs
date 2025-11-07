using UnityEngine;

public class ArrowKeySound : MonoBehaviour
{
    private AudioSource audioSource;
    private float timeBetweenSounds = 0.1f; // Time in seconds between sounds (adjust as needed)
    private float timer = 0f; // Timer to track when to play the next sound

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if any arrow key is being held down
        bool isMoving = Input.GetKey(KeyCode.UpArrow) || 
                        Input.GetKey(KeyCode.DownArrow) || 
                        Input.GetKey(KeyCode.LeftArrow) || 
                        Input.GetKey(KeyCode.RightArrow);

        if (isMoving)
        {
            timer += Time.deltaTime; // Increase the timer by the time that passed

            // Check if enough time has passed since the last sound played
            if (timer >= timeBetweenSounds)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                    timer = 0f; // Reset the timer after playing the sound
                }
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Pause the sound when the key is released
            }
        }
    }
}
