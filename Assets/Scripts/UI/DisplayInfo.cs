using TMPro;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _info;
    
    private bool _needsUpdate = true;
    private uint _currentCostPerClick;
    private uint _currentCostPerWait;
    
    public void MarkForUpdate()
    {
        _needsUpdate = true;
    }

    public void ReturnPreviousValueClick(uint currentCostPerClick)
    {
        _currentCostPerClick = currentCostPerClick;
    }
    
    public void ReturnPreviousValueWait(uint currentCostPerWait)
    {
        _currentCostPerWait = currentCostPerWait;
    }

    private void Update()
    {
        if (_needsUpdate)
        {
            DisplayCurrentInfo();
            _needsUpdate = false;
        }
    }
    
    private void Start()
    {
        DisplayCurrentInfo();
        _currentCostPerClick = 10; 
        _currentCostPerWait = 20;
    }

    private void DisplayCurrentInfo()
    {
        var clickInfo = _currentCostPerClick;
        var waitInfo = _currentCostPerWait;

        _info.text = "Инфо:\n\n" + clickInfo.ToString() + "/клик\n\n" + waitInfo.ToString() + "/сек";
    }
}
