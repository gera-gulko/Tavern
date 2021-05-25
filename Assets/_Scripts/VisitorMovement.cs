using UnityEngine;

public class VisitorMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 currentTarget;
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            if (transform.position == currentTarget)
            {
                isMoving = false;
            }
        }
    }

    public void SetTarget(Vector3 target)
    {
        currentTarget = target;
        isMoving = true;
    }
}
