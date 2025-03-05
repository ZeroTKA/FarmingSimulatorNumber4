using System.Buffers;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // -- To Do List -- //
    // 1. Code review everything. 2.26.25

    [SerializeField] GameObject InventoryMenu;
    private bool isMenuActivated;
    public ItemSlot[] itemSlot;
    private MouseLook mouseLookScript;
    public ItemSO[] itemSO;
    public SeedSO[] seedSO;

    private void Awake()
    {
        mouseLookScript = GameObject.Find("Main Camera").GetComponent<MouseLook>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isMenuActivated = !isMenuActivated;
            InventoryMenu.SetActive(isMenuActivated);
            if (isMenuActivated)
            {
                // I think walking around while menu open is fine but I don't want the camera to rotate.
                mouseLookScript.SetMouseLookStatus(false);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                mouseLookScript.SetMouseLookStatus(true);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    // -- Main Functions -- //
    public int AddItem(string itemName, int quantity, Sprite itemIcon, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isSlotFull && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemIcon, itemDescription);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemIcon, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }
    public void UseItemSO(string itemName)
    {
        for (int i = 0; i < itemSO.Length; i++)
        {
            if (itemSO[i].itemName == itemName)
            {
                itemSO[i].UseItem();
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedItemOverlay.SetActive(false);
            itemSlot[i].isThisItemSelected = false;
        }
    }
}
