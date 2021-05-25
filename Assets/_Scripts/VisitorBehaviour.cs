using UnityEngine;

[RequireComponent(typeof(VisitorMovement))]
public class VisitorBehaviour : MonoBehaviour
{
    private VisitorMovement movement;
    private TavernPlacement tavern;
    private ChairInfo currentChair;

    [SerializeField, Range(0,100)]
    private int changeChairChance = 45;

    private void Awake()
    {
        movement = GetComponent<VisitorMovement>();
        
        tavern = GetComponentInParent<TavernPlacement>();
        if (tavern == null)
        {
            Debug.LogError("Visitor is not in Tavern!");
        }
    }

    private void Start()
    {
        InputManager.OnTriggerAction += ChangeChair;
    }

    private void ChangeChair()
    {
        if ((currentChair == null) || (currentChair != null && IsWillingToChangeChair()))
        {
            ChairInfo newChair = tavern.GetRandomChair();
            if (newChair != null)
            {
                if (currentChair != null)
                {
                    currentChair.IsClaimed = false;
                }
                currentChair = newChair;
                currentChair.IsClaimed = true;

                movement.SetTarget(currentChair.Position);
            }
        }
    }

    private bool IsWillingToChangeChair()
    {
        int rndChance = Random.Range(0, 100);
        if (rndChance < changeChairChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
