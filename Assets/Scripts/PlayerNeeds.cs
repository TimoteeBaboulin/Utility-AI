using System;
using UnityEngine;

public enum Occupancy{
    Nothing,
    Eating,
    Pissing,
    Working
}

public class PlayerNeeds : MonoBehaviour{
    public Transform Transform => transform;
    
    [Header("Hunger")] [SerializeField] private float _hungerSpeed;
    public float Hunger => _hunger;
    [SerializeField] private float _hunger;
    public int MaxHunger => _maxHunger;
    [SerializeField] private int _maxHunger;

    [Header("Natural Needs")] [SerializeField] private float _toiletSpeed;
    public float Toilet => _toilet;
    [SerializeField] private float _toilet;
    public float MaxToilet => _maxToilet;
    [SerializeField] private int _maxToilet;

    [Header("Work")] [SerializeField] private float _workSpeed;
    public float Work => _work;
    [SerializeField] private float _work;
    public int MaxWork => _maxWork;
    [SerializeField] private int _maxWork;
    
    void Update(){
        _hunger -= _hungerSpeed * Time.deltaTime;
        _toilet -= _toiletSpeed * Time.deltaTime;
        _work -= _workSpeed * Time.deltaTime;

        _hunger = Math.Clamp(_hunger, 0, _maxHunger);
        _toilet = Math.Clamp(_toilet, 0, _maxToilet);
        _work = Math.Clamp(_work, 0, _maxWork);
    }
}
