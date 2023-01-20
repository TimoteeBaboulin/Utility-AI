using System.Collections.Generic;
using UnityEngine;

public class Prey : Animal{
    public override FoodType FoodType => FoodType.Plant;

    public static IEnumerator<Prey> LivingPreys{
        get{
            foreach (Prey prey in _livingPreys){
                yield return prey;
            }
        }
    }
    private static readonly List<Prey> _livingPreys = new();

    private void OnEnable(){
        _livingPreys.Add(this);
    }

    private void OnDisable(){
        _livingPreys.Remove(this);
    }

    private void Update(){
        
        
        if (Input.GetButtonDown("Jump")){
            Prey mate = null;

            foreach (var prey in _livingPreys){
                if (prey == this) continue;
                if (mate == null){
                    mate = prey;
                    continue;
                }

                if (mate.MaxHealth < prey.MaxHealth)
                    mate = prey;
            }
            
            if (mate == null) return;

            var child = Instantiate(this, transform.position, transform.rotation);
            child._stats.Reproduce(this, mate);
        }
    }
}

public abstract class Option{
    protected Animal _owner;
    protected AnimalBrainSettings _brainSettings;

    public float Weight => GetWeight();

    protected Option(Animal owner, AnimalBrainSettings brainSettings){
        _owner = owner;
        _brainSettings = brainSettings;
    }

    protected abstract float GetWeight();
}

public class EatOption : Option{
    private Food _food;
    
    public EatOption(Animal owner, AnimalBrainSettings brainSettings, Food food) : base(owner, brainSettings){
        _food = food;
    }

    protected override float GetWeight(){
        float distance = Vector3.Distance(_owner.transform.position, _food.transform.position);

        return _brainSettings.EatUtilityFunction.Evaluate(distance / _brainSettings.MaxFoodDistance);
    }
}