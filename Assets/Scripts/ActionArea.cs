using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ActionArea : MonoBehaviour{
    public Occupancy ActionType;
    
    private void OnTriggerEnter(Collider other){
        PlayerNeeds needs = other.GetComponent<PlayerNeeds>();
        if (needs == null) return;

        needs.CurrentOccupation = ActionType;
    }

    private void OnTriggerExit(Collider other){
        PlayerNeeds needs = other.GetComponent<PlayerNeeds>();
        if (needs == null) return;

        needs.CurrentOccupation = Occupancy.Nothing;
    }
}