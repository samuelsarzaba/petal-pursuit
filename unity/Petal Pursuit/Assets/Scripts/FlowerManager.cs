using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    [SerializeField]
    public int flowerPoints = 0;

    public BouquetDisplay bouquetDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CollectFlower(GameObject flower) {
        if (flower.tag == "Common") {
            flowerPoints += 1;
        }

        if (flower.tag == "Uncommon") {
            flowerPoints += 2;
        }

        if (flower.tag == "Rare") {
            flowerPoints += 3;
        }

        Debug.Log("points: " + flowerPoints);
        bouquetDisplay.UpdateBouquetDisplay(flowerPoints);
    }

    public int GetFlowerPoints()
    {
        return flowerPoints;
    }
}
