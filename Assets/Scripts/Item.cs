using UnityEngine;

public class Item : MonoBehaviour
{
    // -- To Do List -- //


    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite itemIcon;
    [SerializeField][TextArea] private string itemDescription;

    private InventoryManager inventoryManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    // -- Main Functions -- //
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventoryManager.AddItem(itemName, quantity, itemIcon, itemDescription);
            Destroy(gameObject);
        }
    }

}
