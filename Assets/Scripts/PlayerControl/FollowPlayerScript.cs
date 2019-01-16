using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        // move camera along with player
        transform.position = player.position + offset;
    }
}
