using UnityEngine;

public class TavernPlacement : MonoBehaviour
{
    [SerializeField] private GameObject chairsHolder;
    private ChairInfo[] chairs;

    private void Awake()
    {
        chairs = chairsHolder.GetComponentsInChildren<ChairInfo>();
        if (chairs == null)
        {
            Debug.LogError("No Chairs in Tavern!");
        }
    }

    public ChairInfo GetRandomChair()
    {
        bool hasAvailableChairs = false;
        for (int i = 0; i < chairs.Length; i++)
        {
            if (!chairs[i].IsClaimed)
            {
                hasAvailableChairs = true;
                break;
            }
        }
        if (!hasAvailableChairs)
        {
            Debug.LogWarning("Tavern Has No Available Chairs!");
            return null;
        }

        ChairInfo randomChair;
        do
        {
            int rndIndex = Random.Range(0, chairs.Length);
            randomChair = chairs[rndIndex];
        } while (randomChair.IsClaimed);
        return randomChair;
    }
}
