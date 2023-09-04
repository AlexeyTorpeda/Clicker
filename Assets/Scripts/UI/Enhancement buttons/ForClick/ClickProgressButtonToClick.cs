using System;
using UnityEngine;

namespace UI.ForClick
{
    public class ClickProgressButtonToClick : UpgradeButton
    {
        public void ProgressButton()
        {
            if (_gameData?.TotalGold >= _gameData.CurrentCostForBuyClick)
            {
                _gameData.TotalGold -= _gameData.CurrentCostForBuyClick;
                _gameData.CurrentCostPerClick = (uint)(_gameData.CurrentCostPerClick * _progressionConfig.ProgressionMultiplierToClick);
                _gameData.CurrentCostForBuyClick = (uint)(_gameData.CurrentCostForBuyClick * _progressionConfig.ProgressionMultiplierForBuy);
                
                InvokeOnUpgradeCostChanged();
                _clickerGame.OnGoldChanged();
                _displayInfo.MarkForUpdate();
                _displayInfo.ReturnPreviousValueClick(_gameData.CurrentCostPerClick);
            }
            else
            {
                Debug.Log("Не хватает золота");
            }
        }
    }
}