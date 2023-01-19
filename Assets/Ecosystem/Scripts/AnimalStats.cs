using System;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class AnimalStats{
    public int MaxHealth;
    public int MaxHunger;
    public int MaxStamina;
    public int MaxThirst;

    public float WalkingSpeed;
    public float RunningSpeed;

    public AnimalStats(int maxHealth){
        MaxHealth = maxHealth;
    }

    public void Init(int maxHealth){
        MaxHealth = maxHealth;
    }

    public void Reproduce(Animal parentA, Animal parentB){
        MaxHealth = Mathf.FloorToInt(math.lerp(parentA.MaxHealth, parentB.MaxHealth, 0.5f));
        MaxHunger = Mathf.FloorToInt(math.lerp(parentA.MaxHunger, parentB.MaxHunger, 0.5f));
        MaxStamina = Mathf.FloorToInt(math.lerp(parentA.MaxStamina, parentB.MaxStamina, 0.5f));
        MaxThirst = Mathf.FloorToInt(math.lerp(parentA.MaxThirst, parentB.MaxThirst, 0.5f));
        
        WalkingSpeed = Mathf.FloorToInt(math.lerp(parentA.WalkingSpeed, parentB.WalkingSpeed, 0.5f));
        RunningSpeed = Mathf.FloorToInt(math.lerp(parentA.RunningSpeed, parentB.RunningSpeed, 0.5f));
    }
}