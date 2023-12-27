using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterTypes
    {
        Player,
        AI
    }

    [SerializeField] private CharacterTypes characterType;

    public CharacterTypes CharacterType => characterType;
}
