using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/Action/Test")]
public class ActionTest : AIAction
{
    public override void Act(StateController controller)
    {
        Debug.Log("Acting");
    }
}
