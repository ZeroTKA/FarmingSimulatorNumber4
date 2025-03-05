using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "New Seed", menuName = "Scriptable Objects/Seed")]
public class SeedSO : ScriptableObject
{
    [SerializeField] private string seedName;
    [SerializeField] private int seedGrowthTime;
    [SerializeField] private int boostQuality = 1;
    [SerializeField] private int baseSellPrice;
    [SerializeField] private int baseBuyPrice;
    [SerializeField] private int[] yieldRange;
    
    public void PlantSeed()
    {
        Debug.Log("Planting " + seedName);
        // example: GameObject.Find("FarmManager").GetComponent<FarmManager>().PlantSeed(seedName);
    }

    public void HarvestSeed()
    {
        Debug.Log("Harvesting " + seedName);
        // example: GameObject.Find("FarmManager").GetComponent<FarmManager>().HarvestSeed(seedName);
    }

    public void SellSeed()
    {
        Debug.Log("Selling " + seedName);
        // example: GameObject.Find("FarmManager").GetComponent<FarmManager>().SellSeed(seedName);
    }
    public void BuySeed()
    {
        Debug.Log("Selling " + seedName);
        // example: GameObject.Find("FarmManager").GetComponent<FarmManager>().BuySeed(seedName);
    }
}
