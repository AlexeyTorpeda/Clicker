using System.Collections;
using UI.ForClick;
using UI.ForWait;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerGame : MonoBehaviour, IWallet
{
    [SerializeField] private ClickProgressButtonToClick _perClick;
    [SerializeField] private ClickProgressButtonToWait _perWait;
    [SerializeField] private GameData _gameData;
    [SerializeField] private NewHero _perHero;

    private Coroutine _addGoldCoroutine;

    public delegate void GoldChanged(uint totalGold);
    public event GoldChanged OnGoldChangedEvent;

    public void OnGoldChanged()
    {
        OnGoldChangedEvent?.Invoke(_gameData.TotalGold);
    }

    private void Start()
    {
        _addGoldCoroutine = StartCoroutine(AddGoldOverTime());
        _perClick.Initialize(this, _gameData);
        _perWait.Initialize(this, _gameData);
        _perHero.Initialize(this, _gameData);
    }

    private void OnDestroy()
    {
        StopCoroutine(_addGoldCoroutine);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                _gameData.TotalGold += _gameData.CurrentCostPerClick;
                OnGoldChanged();
            }
        }
    }

    private IEnumerator AddGoldOverTime()
    {
        while (gameObject.activeSelf)
        {
            _gameData.TotalGold += _gameData.CurrentCostPerWait;
            OnGoldChanged();
            yield return new WaitForSeconds(1);
        }
    }
}