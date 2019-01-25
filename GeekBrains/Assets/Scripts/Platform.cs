using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 finishPosition;
    public float speed;
    bool end = false;

    void Update()
    {
        if (transform.position == startPosition || transform.position == finishPosition)
            end = !end;

        if (end)
            Move(startPosition);
        else
            Move(finishPosition);        
    }

    void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

}
