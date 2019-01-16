using UnityEngine;

public class PassEndCubeScript : MonoBehaviour
{
    public GameFlowManagerScript gameManager;

    // ensure player not win by fly to end cube
    public PlayerMoveScript playerMove;

    // music
    public AudioSource backgroundAudioSource;
    AudioSource winAudioSource;

    void Start()
    {
        winAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && playerMove.isActiveAndEnabled)
        {
            // stop background music
            backgroundAudioSource.Stop();

            // play win music
            winAudioSource.Play();

            gameManager.CompleteLevel();
        }
    }
}
