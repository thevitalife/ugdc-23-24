using System;
using UnityEngine;
using UnityEngine.Events;
using ContextMenu = DevionGames.UIWidgets.ContextMenu;

public class ContextMenuAction
{
    public string Title { get; set; }
    public Action Callback { get; set; }
}

public class ContextMenuManager : MonoBehaviour
{
    [SerializeField] 
    private ContextMenu contextMenu;

    private Camera mainCamera;
    
    public static ContextMenuManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    public void Show(Vector3 position, params ContextMenuAction[] actions)
    {
        contextMenu.Clear();
        foreach (var contextMenuAction in actions)
        {
            contextMenu.AddMenuItem(contextMenuAction.Title, new UnityAction(contextMenuAction.Callback));
        }
        contextMenu.Show();
        contextMenu.transform.position = mainCamera.WorldToScreenPoint(position);
    }

    public void Hide()
    {
        contextMenu.Close();
    }
}
