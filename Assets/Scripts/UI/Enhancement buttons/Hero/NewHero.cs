using UnityEngine;

public class NewHero : UpgradeButton
{
    public void ProgressButton()
    {
        if (_gameData?.TotalGold >= _gameData.CurrentCostHero)
        {
            _gameData.TotalGold -= _gameData.CurrentCostHero;
            _gameData.CurrentCostHero = (uint)(_gameData.CurrentCostHero * _progressionConfig.ProgressionMultiplierForHero);
            
            InvokeOnUpgradeCostChanged();
            _clickerGame.OnGoldChanged();
        }
        else
        {
            Debug.Log("Не хватает золота");
        }
    }
}
