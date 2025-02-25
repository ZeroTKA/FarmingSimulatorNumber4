using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    // -- To Do List -- //
    // 1. Getting rid of being able to select a slot that has no item.

    // -- Item Data -- //
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isSlotFull;

    // -- Item Slot -- //
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    public GameObject selectedItemOverlay;
    public bool isThisItemSelected;

    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isSlotFull = true;

        itemImage.sprite = itemSprite;
        quantityText.text = quantity.ToString();
        quantityText.gameObject.SetActive(true);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {
        if (selectedItemOverlay.activeSelf)
        {
            selectedItemOverlay.SetActive(false);
            isThisItemSelected = false;
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedItemOverlay.SetActive(true);
            isThisItemSelected = true;
        }        
    }

    public void OnRightClick()
    {
        
    }
}
