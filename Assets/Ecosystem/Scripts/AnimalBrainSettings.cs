using UnityEngine;

[CreateAssetMenu(menuName = "Create AnimalBrainSettings", fileName = "AnimalBrainSettings", order = 0)]
public class AnimalBrainSettings : ScriptableObject{
    public AnimationCurve EatUtilityFunction;
    public float MaxFoodDistance;
}