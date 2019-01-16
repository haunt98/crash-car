using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float[] player_pos;

    public PlayerData(int _level, Transform _player_tf)
    {
        level = _level;

        player_pos = new float[3];
        player_pos[0] = _player_tf.position.x;
        player_pos[1] = _player_tf.position.y;
        player_pos[2] = _player_tf.position.z;
    }
}
