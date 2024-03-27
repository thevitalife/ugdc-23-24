using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private TMP_Text count;

    public void Init(InventoryItem inventoryItem, InventoryItemData inventoryItemData)
    {
        icon.sprite = inventoryItemData.Sprite;
        count.text = inventoryItem.Count.ToString();
    }
}
