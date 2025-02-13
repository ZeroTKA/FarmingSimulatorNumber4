using System.Buffers;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // -- To Do List -- //

    [SerializeField] GameObject InventoryMenu;
    private bool isMenuActivated;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isMenuActivated = !isMenuActivated;
            InventoryMenu.SetActive(isMenuActivated);
        }
    }

    // -- Main Functions -- //
    public void AddItem(string itemName, int quantity, Sprite itemIcon)
    {
        Debug.Log($"Item added: {itemName} x{quantity} + {itemIcon}");
    }
}
