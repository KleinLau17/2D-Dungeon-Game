using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private AIState currentState;
    [SerializeField] private AIState remainState;
    // Returns the target of this Enemy
    public Transform Target { get; set; }
    // Returns a reference to this enemy movement
    public CharacterMovement CharacterMovement { get; set; }
    // Returns this character weapon
    public CharacterWeapon CharacterWeapon { get; set; }
    // Returns a reference to this enemy path
    public Path Path { get; set; }
    // Returns the collider of this enemy
    public Collider2D Collider2D { get; set; }

    private void Awake()
    {
        CharacterMovement = GetComponent<CharacterMovement>();
        CharacterWeapon = GetComponent<CharacterWeapon>();
        Path = GetComponent<Path>();
        Collider2D = GetComponent<Collider2D>();
    }
    private void Update()
    {
        currentState.EvaluateState(this);
    }
    public void TransitionToState(AIState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
