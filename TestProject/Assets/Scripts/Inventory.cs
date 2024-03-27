using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class InventoryItemDto
{
    public string id;
    public int count;
}

[System.Serializable]
public class InventoryDto
{
    public InventoryItemDto[] items;
}

public class InventoryItem
{
    public string Id { get; set; }
    public int Count { get; set; }
}

public class Inventory : MonoBehaviour
{
    private const string InventoryKey = "Inventory";

    private Dictionary<string, InventoryItem> items = new Dictionary<string, InventoryItem>();

    public event EventHandler<IReadOnlyDictionary<string, InventoryItem>> OnInventoryChanged;

    public IReadOnlyDictionary<string, InventoryItem> Items => items;

    private void Start()
    {
        if (PlayerPrefs.HasKey(InventoryKey))
        {
            string str = PlayerPrefs.GetString(InventoryKey);
            InventoryDto inventoryDto = JsonUtility.FromJson<InventoryDto>(str);
            foreach (var item in inventoryDto.items)
            {
                items[item.id] = new InventoryItem { Id = item.id, Count = item.count };
            }
            OnInventoryChanged?.Invoke(this, Items);
        }
    }


    public void Add(string id, int count = 1)
    {
        if (items.ContainsKey(id))
        {
            items[id].Count += count;
        }
        else
        {
            items[id] = new InventoryItem() { Id = id, Count = count };
        }
        Debug.Log($"Added {count} inventory item {id}");
        SyncInventory();
    }

    private void SyncInventory()
    {
        LogInventory();
        InventoryDto dto = new InventoryDto();
        dto.items = items.Select(keyValuePair => new InventoryItemDto() { id = keyValuePair.Value.Id, count = keyValuePair.Value.Count }).ToArray();
        string json = JsonUtility.ToJson(dto);
        PlayerPrefs.SetString(InventoryKey, json);
        OnInventoryChanged?.Invoke(this, Items);
    }

    public bool Contains(string id, int count = 1)
    {
        return items.ContainsKey(id) && items[id].Count >= count;
    }

    public void LogInventory()
    {
        StringBuilder log = new StringBuilder($"Inventory contains {items.Count}\n");

        foreach (var item in items)
        {
            log.AppendLine($"{item.Key} - {item.Value.Count}");
        }

        Debug.Log(log);
    }
}