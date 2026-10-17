using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int food = 3; // = to przypisanie wartoœci
    public int population;
    public int populationLimit;
    public TMP_Text foodText;
    public TMP_Text populationText;

    public void AddPoints(int addedPoints, ResorceType resource)
    {
        if(resource == ResorceType.Food)
        {
            food += addedPoints;
            foodText.text = "food: " + food.ToString();
        }
        else if(resource == ResorceType.Population)
        {
            population += addedPoints;
            populationText.text = "population: " + population.ToString();
        }
    }

    public bool TrySpendPoints(int cost, ResorceType resource)
    {
        if(resource == ResorceType.Food)
        {
            if (food >= cost)
            {
                food -= cost;
                foodText.text = "food: " + food.ToString();
                return true;
            }
        }
        else if ( resource == ResorceType.Population)
        {
            if (population >= cost)
            {
                population -= cost;
                populationText.text = "population: " + population.ToString();
                return true;
            }
        }
        return false;
    }
}
