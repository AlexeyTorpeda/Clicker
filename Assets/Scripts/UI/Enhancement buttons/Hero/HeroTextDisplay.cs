using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroTextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeCostText;
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameConfig _heroProgression;
    [SerializeField] private NewHero _newHero;

    private void Start()
    {
        _newHero.OnUpgradeCostChanged += UpdateUpgradeCost;
        UpdateUpgradeCost();
    }
    
    private void OnDestroy()
    {
        _newHero.OnUpgradeCostChanged -= UpdateUpgradeCost;
    }

    private void UpdateUpgradeCost()
    {
        var improveTo = (uint)(_gameData.CurrentCostHero * _heroProgression.ProgressionMultiplierForHero);
        _upgradeCostText.text = "Новый персонаж за " + improveTo;
    }
}