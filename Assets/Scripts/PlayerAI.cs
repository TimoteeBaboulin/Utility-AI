using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour{
    [Header("Player")] 
    [SerializeField] private PlayerNeeds _player;
    [SerializeField] private NavMeshAgent _agent;

    [Header("Options")] 
    [SerializeField] private Occupancy _occupancy;

    [SerializeField] private Transform _computer;
    [SerializeField] private Transform _fridge;
    [SerializeField] private Transform _toilet;
    
    [Header("Utility Functions")] 
    [SerializeField] private AnimationCurve _workPercentFunction;
    [SerializeField] private AnimationCurve _hungerPercentFunction;
    [SerializeField] private AnimationCurve _toiletPercentFunction;

    [Header("Weights")] 
    [SerializeField] [Range(-100, 100)] private float _workPercentWeight;
    [SerializeField] [Range(-100, 100)] private float _hungerPercentWeight;
    [SerializeField] [Range(-100, 100)] private float _toiletPercentWeight;

    public float WorkPercentSample => 1 -_workPercentFunction.Evaluate(_player.Work / _player.MaxWork);
    public float HungerPercentSample => 1 - _hungerPercentFunction.Evaluate(_player.Hunger / _player.MaxHunger);
    public float ToiletPercentSample => 1 - _toiletPercentFunction.Evaluate(_player.Toilet / _player.MaxToilet);
    
    public float TotalDistance {
        get{
            float distance = 0;
            distance += Vector3.Distance(transform.position, _computer.position) +
                        Vector3.Distance(transform.position, _fridge.position) +
                        Vector3.Distance(transform.position, _toilet.position);
            return distance;
        }
    }

    public float WorkDistanceSample{
        get{
            return Vector3.Distance(transform.position, _computer.position) / TotalDistance;
        }
    }

    private void Update(){
        
    }
}
