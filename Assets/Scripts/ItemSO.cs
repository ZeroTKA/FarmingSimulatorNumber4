using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;
    public int MaxNumberOfItems;

    public void UseItem()
    {
        if (statToChange == StatToChange.Health)
        {
            Debug.Log("Changing " + statToChange + " by " + amountToChangeStat);
            // example: GameObject.Find("HealthManager").GetComponent<HealthManager>().ChangeHealth(amountToChangeStat);
        }

    }

    public enum StatToChange
    {
        None,
        Health,
        Speed,
        Damage
    }
    public enum AttributeToChange
    {
        None,
        Strength,
        Dexterity,
        Intelligence
    }
}
