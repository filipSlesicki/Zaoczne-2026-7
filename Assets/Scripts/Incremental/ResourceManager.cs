using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int food = 3; // = to przypisanie wartoœci
    public int population;
    public int populationLimit;
    public TMP_Text foodText;
    public TMP_Text populationText;

    public void AddResource(int addedPoints, ResorceType resource)
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

    /// <summary>
    /// Sprawdza czy mam doœæ zasobów i jeœli tak, to odejmuje zasoby
    /// </summary>
    /// <param name="cost">ile próbubujê wydaæ</param>
    /// <param name="resource">typ zasobów</param>
    /// <returns>Czy uda³o siê wydaæ zasoby</returns>
    public bool TrySpendResource(int cost, ResorceType resource)
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
                populationText.text = $"population: {population}/{populationLimit}";
                return true;
            }
        }
        return false;
    }
}
