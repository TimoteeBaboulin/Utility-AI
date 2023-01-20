using System;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType{
    Plant,
    Meat
}

public abstract class Food : MonoBehaviour{
    public static event Action<FoodType> OnFoodSpawn;
    
    public static List<Food> Plants = new();
    public static List<Food> Meats = new();
    
    public int FeedAmount;
    public FoodType FeedType;
    public event Action OnFoodDeath;

    private void OnEnable(){
        if (FeedType == FoodType.Meat)
            Meats.Add(this);
        else
            Plants.Add(this);
        
        OnFoodSpawn?.Invoke(FeedType);
    }

    private void OnDisable(){
        OnFoodDeath?.Invoke();
    }

    private void OnTriggerEnter(Collider other){
        Animal animal;
        if ((animal = other.GetComponent<Animal>()) == null) return;
        if (animal.FoodType != FeedType) return;
        
        animal.Eat(FeedAmount);
    }
}