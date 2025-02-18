using System.Buffers;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // -- To Do List -- //

    [SerializeField] GameObject InventoryMenu;
    private bool isMenuActivated;
    public ItemSlot[] itemSlot;
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
        for(int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isSlotFull)
            {
                itemSlot[i].AddItem(itemName, quantity, itemIcon);
                break;
            }
        }
    }
}
