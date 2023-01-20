using System;
using UnityEngine;

[Serializable]
public abstract class Animal : MonoBehaviour{
    public abstract FoodType FoodType{ get; }
    
    public int MaxHealth => _stats.MaxHealth;
    public int MaxHunger => _stats.MaxHunger;
    public int MaxStamina => _stats.MaxStamina;
    public int MaxThirst => _stats.MaxThirst;

    public float WalkingSpeed => _stats.WalkingSpeed;
    public float RunningSpeed => _stats.RunningSpeed;
    
    public float CurrentHealth => _currentHealth;
    [Header("Runtime debug, do not touch!")]
    [SerializeField] protected float _currentHealth;
    public float CurrentHunger => _currentHunger;
    [SerializeField] protected float _currentHunger;
    public float CurrentStamina => _currentStamina;
    [SerializeField] protected float _currentStamina;
    public float CurrentThirst => _currentThirst;
    [SerializeField] protected float _currentThirst;
    
    public AnimalStats Stats => _stats;
    [SerializeField] protected AnimalStats _stats;

    [ContextMenu("Log MaxHealth")]
    public void LogHealth(){
        Debug.Log(_currentHealth);
    }

    private void Start(){
        _currentHealth = MaxHealth;
        _currentHunger = MaxHunger;
        _currentStamina = MaxStamina;
        _currentThirst = MaxThirst;
    }
    private void FixedUpdate(){
        if (GameManager.Instance == null){
            Debug.Log("GameManager not found");
            return;
        }
        _currentHunger -= GameManager.Instance.HungerLossSpeed * GameManager.GameSpeed * Time.fixedDeltaTime;
        _currentStamina -= GameManager.Instance.StaminaLossSpeed * GameManager.GameSpeed * Time.fixedDeltaTime;
        _currentThirst -= GameManager.Instance.ThirstLossSpeed * GameManager.GameSpeed * Time.fixedDeltaTime;
    }

    public void Eat(int amount){
        _currentHunger += amount;
        _currentHunger = Math.Clamp(0, MaxHunger, _currentHunger);
    }
}