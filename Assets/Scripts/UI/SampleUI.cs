using UnityEngine;
using UnityEngine.UI;

public class SampleUI : MonoBehaviour{
    [SerializeField] private PlayerAI _AI;
    [SerializeField] private Image _hungerBar;
    [SerializeField] private Image _toiletBar;
    [SerializeField] private Image _workBar;

    private void Update(){
        _hungerBar.fillAmount = _AI.HungerPercentSample;
        _toiletBar.fillAmount = _AI.ToiletPercentSample;
        _workBar.fillAmount = _AI.WorkPercentSample;
    }
}