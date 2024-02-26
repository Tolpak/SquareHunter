using TMPro;
using UnityEngine;
using Zenject;

public class Overlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI distanceLabel;
    private ProgressManager progressManager;

    [Inject]
    public void Construct(ProgressManager progressManager )
    {
        this.progressManager = progressManager;
    }

    private void Update()
    {
        scoreLabel.text = progressManager.Score.ToString();
        distanceLabel.text = progressManager.Distance.ToString();
    }
}
