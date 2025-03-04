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
    [SerializeField] Image itemDescriptionImage;
    [SerializeField] TMP_Text itemDescriptionNameText;
    [SerializeField] TMP_Text itemDescriptionText;



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

        // if it doesn't all fit
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

        // it all fits.
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
        if (isThisItemSelected & this.quantity > 0)
        {
            inventoryManager.UseItemSO(itemName);
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity == 0)
            {
                EmptySlot();
                inventoryManager.DeselectAllSlots();
            }
        }
        else
        {
            // Have to make sure only one thing is selected at a time.
            inventoryManager.DeselectAllSlots();
            selectedItemOverlay.SetActive(true);
            isThisItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionNameText.gameObject.SetActive(true);
            itemDescriptionText.text = itemDescription;
            itemDescriptionText.gameObject.SetActive(true);
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

    public void EmptySlot()
    {
        itemImage.sprite = emptySprite;

        itemDescriptionNameText.text = "";
        itemName = "";
        itemDescriptionText.text = "";
        itemDescription = "";
        itemDescriptionImage.sprite = emptySprite;
        itemImage.sprite = emptySprite;
        itemSprite = null;


    }
}
