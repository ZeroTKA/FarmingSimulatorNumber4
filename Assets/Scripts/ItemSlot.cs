using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    // -- To Do List -- //
    // 1. Getting rid of being able to select a slot that has no item.
    // 2. Make sprite emptySprite ACTUALLY empty.
    // 3. Pass along max number of items to the inventory manager from the ITEM.

    // -- Item Data -- //
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isSlotFull;
    public string itemDescription;
    public Sprite emptySprite;

    // -- Item Slot -- //
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int maxNumberOfItems;

    public GameObject selectedItemOverlay;
    public bool isThisItemSelected;

    // -- Item Description -- //
    public Image itemDescriptionImage;
    public TMP_Text _itemDescriptionNameText;
    public TMP_Text _itemDescriptionText;



    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        if (isSlotFull)
        {
            return quantity;
        }

        this.itemName = itemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.itemDescription = itemDescription;
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.gameObject.SetActive(true);
            isSlotFull = true;

            //Return left over items
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }
        quantityText.text = this.quantity.ToString();
        quantityText.gameObject.SetActive(true);
        return 0;
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
            _itemDescriptionNameText.gameObject.SetActive(false);
            _itemDescriptionText.gameObject.SetActive(false);
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedItemOverlay.SetActive(true);
            isThisItemSelected = true;
            _itemDescriptionNameText.text = itemName;
            _itemDescriptionNameText.gameObject.SetActive(true);
            _itemDescriptionText.text = itemDescription;
            _itemDescriptionText.gameObject.SetActive(true);
            itemDescriptionImage.sprite = itemSprite;
            if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }
        }
    }

    public void OnRightClick()
    {

    }
}
