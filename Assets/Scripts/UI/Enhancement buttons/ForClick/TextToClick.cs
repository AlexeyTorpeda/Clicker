using TMPro;
using UI.ForClick;
using UnityEngine;

public class TextToClick : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeCostText;
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameConfig _clickProgression;
    [SerializeField] private ClickProgressButtonToClick _clickProgressButtonToClick;

    private void Start()
    {
        _clickProgressButtonToClick.OnUpgradeCostChanged += UpdateUpgradeCost;
        UpdateUpgradeCost();
    }
    
    private void OnDestroy()
    {
        _clickProgressButtonToClick.OnUpgradeCostChanged -= UpdateUpgradeCost;
    }

    private void UpdateUpgradeCost()
    {
        var improveTo = (uint)(_gameData.CurrentCostPerClick * _clickProgression.ProgressionMultiplierToClick);
        var improveFor = (uint)(_gameData.CurrentCostForBuyClick * _clickProgression.ProgressionMultiplierForBuy);
        _upgradeCostText.text = "Улучшить до " + improveTo + "/клик \nза " + improveFor;
    }
}