using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public GameFlowManagerScript gameManager;

    Rigidbody player_rb;

    public float forwardForce;
    public float sideforce;

    void Start()
    {
        player_rb = GetComponent<Rigidbody>();

        if (PlayerPrefs.GetInt("isLoadGame") == 1)
        {
            PlayerPrefs.SetInt("isLoadGame", 0);
            PlayerData playerData = SaveGame.Load();

            // set player position
            transform.position = new Vector3(
                playerData.player_pos[0],
                playerData.player_pos[1],
                playerData.player_pos[2]);
        }

        // hide cursor
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        // always move forward
        // force on Oz
        player_rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player_rb.AddForce(-sideforce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player_rb.AddForce(sideforce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // fall out of ground
        if (player_rb.position.y <= 0f)
        {
            gameManager.GameOver();
        }
    }
}
