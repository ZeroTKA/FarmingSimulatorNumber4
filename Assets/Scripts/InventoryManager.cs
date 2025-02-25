using System.Buffers;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // -- To Do List -- //

    [SerializeField] GameObject InventoryMenu;
    private bool isMenuActivated;
    public ItemSlot[] itemSlot;
    private MouseLook mouseLookScript;
    // Update is called once per frame
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

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedItemOverlay.SetActive(false);
            itemSlot[i].isThisItemSelected = false;
        }
    }
}
