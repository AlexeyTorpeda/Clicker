using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GamePlay/New Config")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private double _progressionMultiplierToClick = 1.1;
    [SerializeField] private double _progressionMultiplierToWait = 1.15;
    [SerializeField] private double _progressionMultiplierForBuy = 1.13;
    [SerializeField] private double _progressionMultiplierForHero = 1.2;

    public double ProgressionMultiplierToClick => _progressionMultiplierToClick;
    public double ProgressionMultiplierToWait => _progressionMultiplierToWait;
    public double ProgressionMultiplierForBuy => _progressionMultiplierForBuy;
    public double ProgressionMultiplierForHero => _progressionMultiplierForHero;
}
