using System;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static float GameSpeed = 1;
    public static event Action OnGameEnd;

    public static GameManager Instance;

    public float HungerLossSpeed;
    public float StaminaLossSpeed;
    public float ThirstLossSpeed;

    private void Start(){
        Instance = this;
        GameSpeed = 1;
    }
}