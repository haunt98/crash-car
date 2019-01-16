using UnityEngine;

public class PlayerCollideScript : MonoBehaviour
{
    public GameFlowManagerScript gameManager;
    public PlayerMoveScript playerMove;

    // crash sound
    public AudioSource crashAudioSource;

    // background music
    public AudioSource backgroundAudioSource;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hit obstacle");

            // stop moving
            playerMove.enabled = false;

            // stop background music
            backgroundAudioSource.Stop();

            // play crash sound
            crashAudioSource.Play();

            gameManager.GameOver();
        }
    }
}
