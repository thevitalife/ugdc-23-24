using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "Inventory/ItemData")]
public class InventoryItemData : ScriptableObject
{
    [SerializeField]
    private string id;

    [SerializeField]
    private Sprite sprite;

    public string Id => id;
    public Sprite Sprite => sprite;
}
