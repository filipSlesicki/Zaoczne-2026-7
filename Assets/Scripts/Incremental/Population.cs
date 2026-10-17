using UnityEngine;

public class Population : MonoBehaviour
{
    public ResourceManager pointsManager;
    public int populationFoodCost = 1;
    public float costIncreaseMultiplier = 1.15f;

    public void IncreasePopulation()
    {
        if(pointsManager.TrySpendResource(populationFoodCost, ResorceType.Food))
        {
            pointsManager.AddResource(1, ResorceType.Population);
            populationFoodCost = (int)(populationFoodCost *costIncreaseMultiplier);
        }
    }

}
