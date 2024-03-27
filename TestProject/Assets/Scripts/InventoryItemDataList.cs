using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemDataList", menuName = "Inventory/ItemDataList")]
public class InventoryItemDataList : ScriptableObject
{
    [SerializeField]
    private List<InventoryItemData> inventoryItems;

    public InventoryItemData GetItemData(string id)
    {
        return inventoryItems.Find(itemData => itemData.Id == id);
    }
}
