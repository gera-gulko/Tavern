using UnityEngine;

public class ChairInfo : MonoBehaviour
{
    public Vector3 Position { get; private set; }
    public bool IsClaimed { get; set; }

    private void Start()
    {
        Position = transform.position;
    }
}
