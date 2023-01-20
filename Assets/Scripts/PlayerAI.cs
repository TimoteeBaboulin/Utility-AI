using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PlayerAI : MonoBehaviour{
    [Header("Player")] 
    [SerializeField] private PlayerNeeds _player;
    [SerializeField] private NavMeshAgent _agent;

    [Header("Options")]
    [SerializeField] private Transform _computer;
    [SerializeField] private Transform _fridge;
    [SerializeField] private Transform _toilet;
    
    [Header("Utility Functions")] 
    [SerializeField] private AnimationCurve _workDistanceFunction; 
    [SerializeField] private AnimationCurve _hungerDistanceFunction;
    [SerializeField] private AnimationCurve _toiletDistanceFunction;

    [Header("Weights")] 
    [SerializeField] [Range(-100, 100)] private float _workPercentWeight;
    [SerializeField] [Range(-100, 100)] private float _hungerPercentWeight;
    [SerializeField] [Range(-100, 100)] private float _toiletPercentWeight;
    
    public float WorkPercentSample => 1 -_workDistanceFunction.Evaluate(WorkDistance / TotalDistance);
    public float HungerPercentSample => 1 - _hungerDistanceFunction.Evaluate(FridgeDistance / TotalDistance);
    public float ToiletPercentSample => 1 - _toiletDistanceFunction.Evaluate(ToiletDistance / TotalDistance);
    
    public float TotalDistance;

    public float WorkDistance;
    public float FridgeDistance;
    public float ToiletDistance;

    private void Update(){
        CalculateDistances();
        
        
        
        Debug.Log("Work: " + Math.Round(WorkDistance) + "/" + Math.Round(TotalDistance) + "\n" 
                  + "Fridge: " + Math.Round(FridgeDistance) + "/" + Math.Round(TotalDistance) + "\n" 
                  + "Toilet: " + Math.Round(ToiletDistance) + "/" + Math.Round(TotalDistance));
    }

    private void CalculateDistances(){
        WorkDistance = transform.GetNavMeshDistanceTo(_computer);
        FridgeDistance = transform.GetNavMeshDistanceTo(_fridge);
        ToiletDistance = transform.GetNavMeshDistanceTo(_toilet);
        TotalDistance = WorkDistance + FridgeDistance + ToiletDistance;
    }

    private void ChooseOccupation(){
        
    }
}