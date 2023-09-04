using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalGoldText;
    [SerializeField] private ClickerGame _clickerGame;

    void Start()
    {
        _clickerGame.OnGoldChangedEvent += UpdateScore;
    }

    void UpdateScore(uint totalGold)
    {
        _totalGoldText.text = totalGold.ToString();
    }
}