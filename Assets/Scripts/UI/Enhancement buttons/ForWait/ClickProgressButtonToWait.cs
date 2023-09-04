using System;
using UnityEngine;

namespace UI.ForWait
{
    public class ClickProgressButtonToWait : UpgradeButton
    {
        public void ProgressButton()
        {
            if (_gameData?.TotalGold >= _gameData.CurrentCostForBuyWait)
            {
                _gameData.TotalGold -= _gameData.CurrentCostForBuyWait;
                _gameData.CurrentCostPerWait = (uint)(_gameData.CurrentCostPerWait * _progressionConfig.ProgressionMultiplierToWait);
                _gameData.CurrentCostForBuyWait = (uint)(_gameData.CurrentCostForBuyWait * _progressionConfig.ProgressionMultiplierForBuy);

                InvokeOnUpgradeCostChanged();
                _clickerGame.OnGoldChanged();
                _displayInfo.MarkForUpdate();
                _displayInfo.ReturnPreviousValueWait(_gameData.CurrentCostPerWait);
            }
            else
            {
                Debug.Log("Не хватает золота");
            }
        }
    }
}