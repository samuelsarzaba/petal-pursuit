using UnityEngine;
using UnityEngine.UI;

public class BouquetDisplay : MonoBehaviour
{
    [SerializeField] private Image bouquetImage;
    [SerializeField] public Sprite[] bouquetSprites;

    void Start()
    {
        if (bouquetSprites == null || bouquetSprites.Length != 8)
        {
            Debug.LogError("Bouquet sprites array must contain exactly 8 sprites.");
            return;
        }

        UpdateBouquetDisplay(0); // Initialize with 0 flower points
    }

    public void UpdateBouquetDisplay(int flowerPoints)
    {
        int index = Mathf.Clamp(flowerPoints / 10, 0, 7); // Assuming each bouquet level requires 10 points
        bouquetImage.sprite = bouquetSprites[index];
    }
}
