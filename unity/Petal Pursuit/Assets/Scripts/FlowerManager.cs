using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    [SerializeField]
    public int flowerPoints = 0;

    [SerializeField]
    private BouquetManager bouquetManager;

    void Start()
    {
        bouquetManager = FindObjectOfType<BouquetManager>();
    }

    public void CollectFlower(GameObject flower) {
        if (flower.tag == "Common") {
            flowerPoints += 1;
            if (bouquetManager != null)
                bouquetManager.AddCommonFlower();
        }

        if (flower.tag == "Uncommon") {
            flowerPoints += 2;
            if (bouquetManager != null)
                bouquetManager.AddUncommonFlower();
        }

        if (flower.tag == "Rare") {
            flowerPoints += 3;
            if (bouquetManager != null)
                bouquetManager.AddRareFlower();
        }

        Debug.Log("points: " + flowerPoints);
    }

    public int GetFlowerPoints()
    {
        return flowerPoints;
    }
}
