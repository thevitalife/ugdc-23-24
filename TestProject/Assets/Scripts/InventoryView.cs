using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private InventoryItemView original;

    [SerializeField]
    private InventoryItemDataList dataList;

    [SerializeField]
    private RectTransform parent;

    [SerializeField]
    private Inventory inventory;

    private void OnEnable()
    {
        inventory.OnInventoryChanged += Inventory_OnInventoryChanged;
        Inventory_OnInventoryChanged(this, inventory.Items);
    }

    private void Inventory_OnInventoryChanged(object sender, IReadOnlyDictionary<string, InventoryItem> items)
    {
        foreach (var item in parent)
        {
            Destroy((item as Transform).gameObject);
        }

        foreach (var item in items)
        {
            var data = dataList.GetItemData(item.Key);
            InventoryItemView newItem = Instantiate(original, parent);
            newItem.Init(item.Value, data);
        }
    }

    private void OnDisable()
    {
        inventory.OnInventoryChanged -= Inventory_OnInventoryChanged;
    }

}
