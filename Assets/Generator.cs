using TMPro;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public ResorceType generatedResource;
    public ResorceType upgradeGenerationResource;
    public PointsManager pointsManager;
    private int autoPointsGain = 0;
    public int autoPointsGainPerUpgrade = 1;
    public int autoPointsUpgradeCost = 10;
    public float autoPointsGainInterval = 1.0f;
    public TMP_Text upgradeAutoPointsText;
    private float autoPointsTimer;
    public TMP_Text pointsAddedText;
    public TMP_Text upgradeCostText;
    public int addedPointsPerClick = 1;
    public int clickUpgradeCost = 10;
    public int clicks;

    private void Start()
    {
        upgradeAutoPointsText.text = $"{name} {autoPointsGain}/s ({autoPointsUpgradeCost})";
    }

    void Update()
    {
        // Timer
        autoPointsTimer -= Time.deltaTime;
        if (autoPointsTimer < 0)
        {
            AddAutoPoints();
            autoPointsTimer = autoPointsGainInterval;
        }
    }

    public void UpgradeAutoPoints()
    {
        if (pointsManager.TrySpendPoints( autoPointsUpgradeCost, upgradeGenerationResource))
        {
            autoPointsGain += autoPointsGainPerUpgrade;
            autoPointsUpgradeCost += 10;
            upgradeAutoPointsText.text = $" {name} {autoPointsGain}/s ({autoPointsUpgradeCost})";
        }
    }

    public void UpgradeGainInterval()
    {
        autoPointsGainInterval *= 0.9f;
    }

    public void AddClickPoints()
    {
        pointsManager.AddPoints(addedPointsPerClick, generatedResource);
        clicks++;
    }

    public void UpgradePointsPerClick()
    {
        if (pointsManager.TrySpendPoints(clickUpgradeCost, generatedResource))
        {
            addedPointsPerClick++;
            clickUpgradeCost += clicks;
            pointsAddedText.text = $"Add points ({addedPointsPerClick})";
            upgradeCostText.text = "Upgrade " + clickUpgradeCost.ToString();
        }
        else
        {
            print("Not enough points");
        }
    }

    private void AddAutoPoints()
    {
        pointsManager.AddPoints(autoPointsGain, generatedResource);
    }
}
