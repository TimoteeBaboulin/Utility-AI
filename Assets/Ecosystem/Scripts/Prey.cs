using System;
using System.Collections.Generic;
using UnityEngine;

public class Prey : Animal{
    public static IEnumerator<Prey> LivingPreys{
        get{
            foreach (Prey prey in _livingPreys){
                yield return prey;
            }
        }
    }
    private static List<Prey> _livingPreys = new();

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