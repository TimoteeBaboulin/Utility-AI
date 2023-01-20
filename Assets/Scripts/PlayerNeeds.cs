using System;
using UnityEngine;

public enum Occupancy{
    Nothing = 0,
    Eating = 1,
    Pissing = 2,
    Working = 3
}

public class PlayerNeeds : MonoBehaviour{
    private static float[,] NeedsDropSpeed ={
        { 2, 2, 2},
        { -8, 2, 2},
        { 2, -8, 2},
        { 2, 2, -8}
    };
    
    public Transform Transform => transform;

    public Occupancy CurrentOccupation = Occupancy.Nothing;
    
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
        _hunger -= NeedsDropSpeed[(int) CurrentOccupation, 0] * Time.deltaTime;
        _toilet -= NeedsDropSpeed[(int) CurrentOccupation, 1] * Time.deltaTime;
        _work -= NeedsDropSpeed[(int) CurrentOccupation, 2] * Time.deltaTime;

        _hunger = Math.Clamp(_hunger, 0, _maxHunger);
        _toilet = Math.Clamp(_toilet, 0, _maxToilet);
        _work = Math.Clamp(_work, 0, _maxWork);
        
        if (_hunger == 0 || _toilet == 0 || _work == 0) Destroy(gameObject);
    }
}
