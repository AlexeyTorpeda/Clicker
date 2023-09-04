using System;
using UnityEngine;

public abstract class UpgradeButton : MonoBehaviour
{
    [SerializeField] protected GameConfig _progressionConfig;
    [SerializeField] protected DisplayInfo _displayInfo;
    [SerializeField] protected GameData _gameData;

    protected IWallet _clickerGame;

    public event Action OnUpgradeCostChanged;

    protected void Start()
    {
        OnUpgradeCostChanged?.Invoke();
    }
    
    protected void InvokeOnUpgradeCostChanged()
    {
        OnUpgradeCostChanged?.Invoke();
    }

    public void Initialize(IWallet clickerGame, GameData gameData)
    {
        _clickerGame = clickerGame;
        _gameData = gameData;
    }
}