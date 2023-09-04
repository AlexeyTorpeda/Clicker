using TMPro;
using UI.ForWait;
using UnityEngine;

public class TextToWait : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeCostText;
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameConfig _waitProgression;
    [SerializeField] private ClickProgressButtonToWait _clickProgressButtonToWait;

    private void Start()
    {
        _clickProgressButtonToWait.OnUpgradeCostChanged += UpdateUpgradeCost;
        UpdateUpgradeCost();
    }
    
    private void OnDestroy()
    {
        _clickProgressButtonToWait.OnUpgradeCostChanged -= UpdateUpgradeCost;
    }

    private void UpdateUpgradeCost()
    {
        var improveTo = (uint)(_gameData.CurrentCostPerWait * _waitProgression.ProgressionMultiplierToWait);
        var improveFor = (uint)(_gameData.CurrentCostForBuyWait * _waitProgression.ProgressionMultiplierForBuy);
        _upgradeCostText.text = "Улучшить до " + improveTo + "/сек \nза " + improveFor;
    }
}