using UnityEngine;
using UnityEngine.UI;

public class NeedUI : MonoBehaviour{
    [SerializeField] private PlayerNeeds _player;
    [SerializeField] private Image _hungerBar;
    [SerializeField] private Image _toiletBar;
    [SerializeField] private Image _workBar;

    private void Update(){
        if (_player == null) return;
        
        _hungerBar.fillAmount = _player.Hunger / _player.MaxHunger;
        _toiletBar.fillAmount = _player.Toilet / _player.MaxToilet;
        _workBar.fillAmount = _player.Work / _player.MaxWork;
    }
}