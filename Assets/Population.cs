using UnityEngine;

public class Population : MonoBehaviour
{
    public PointsManager pointsManager;
    public int populationFoodCost = 1;
    public int populationCostIncrease = 10;

    public void IncreasePopulation()
    {
        if(pointsManager.TrySpendPoints(populationFoodCost, ResorceType.Food))
        {
            pointsManager.AddPoints(1, ResorceType.Population);
            populationFoodCost += populationCostIncrease;
        }
    }

}
