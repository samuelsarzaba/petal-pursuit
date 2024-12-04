using UnityEngine;
using UnityEngine.UI;

public class BouquetManager : MonoBehaviour
{
    [SerializeField]
    private GameObject commonFlowerPrefab;
    
    [SerializeField]
    private GameObject uncommonFlowerPrefab;
    
    [SerializeField]
    private GameObject rareFlowerPrefab;

    [SerializeField]
    private Transform bouquetContainer; // Parent object to hold flowers

    private Vector2[] commonPositions = {
        new Vector2(-50, 0),
        new Vector2(50, 0),
        new Vector2(0, 50),
        new Vector2(-25, 100),
        new Vector2(25, 100)
    };

    private Vector2[] uncommonPositions = {
        new Vector2(-75, 50),
        new Vector2(75, 50),
        new Vector2(0, 150)
    };

    private Vector2[] rarePositions = {
        new Vector2(0, 200)
    };

    private int commonCount = 0;
    private int uncommonCount = 0;
    private int rareCount = 0;

    public void AddCommonFlower()
    {
        if (commonCount < commonPositions.Length)
        {
            GameObject flower = Instantiate(commonFlowerPrefab, bouquetContainer);
            flower.GetComponent<RectTransform>().anchoredPosition = commonPositions[commonCount];
            commonCount++;
        }
    }

    public void AddUncommonFlower()
    {
        if (uncommonCount < uncommonPositions.Length)
        {
            GameObject flower = Instantiate(uncommonFlowerPrefab, bouquetContainer);
            flower.GetComponent<RectTransform>().anchoredPosition = uncommonPositions[uncommonCount];
            uncommonCount++;
        }
    }

    public void AddRareFlower()
    {
        if (rareCount < rarePositions.Length)
        {
            GameObject flower = Instantiate(rareFlowerPrefab, bouquetContainer);
            flower.GetComponent<RectTransform>().anchoredPosition = rarePositions[rareCount];
            rareCount++;
        }
    }
}
