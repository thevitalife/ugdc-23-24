using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuUIController : MonoBehaviour
{
    [SerializeField]
    private InventoryView inventoryView;

    [SerializeField]
    private GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryView.SwitchShowing();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
        }
    }
}
