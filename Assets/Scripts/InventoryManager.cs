using System.Buffers;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] GameObject InventoryMenu;
    private bool isMenuActivated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isMenuActivated = !isMenuActivated;
            InventoryMenu.SetActive(isMenuActivated);
        }
    }
}
