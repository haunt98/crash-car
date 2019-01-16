using UnityEngine;

public class AI_ObstacleScript : MonoBehaviour
{
    // how far to move left, right
    public float delta;
    public float speed;
    Vector3 startBodyPos;
    Vector3 startBoxCollidePos;

    void Start()
    {
        startBodyPos = transform.position;
        startBoxCollidePos = GetComponent<BoxCollider>().transform.position;
    }

    void Update()
    {
        // https://answers.unity.com/questions/754633/how-to-move-an-object-left-and-righ-looping.html
        // new body pos
        Vector3 newBodyPos = startBodyPos;
        newBodyPos.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = newBodyPos;

        // new box collide pos
        Vector3 newBoxCollidePos = startBoxCollidePos;
        newBoxCollidePos.x += delta * Mathf.Sin(Time.time * speed);
        GetComponent<BoxCollider>().transform.position = newBoxCollidePos;
    }
}
