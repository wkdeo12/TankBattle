using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MoveFunctionList { MoveFoward, MoveBackward, RotateRight, RotateLeft }

public class FunctionDataBase : MonoBehaviour
{
    private List<Action> moveFuncDataBase = new List<Action>();

    private void Start()
    {
        ListUp();
    }

    public void ListUp()
    {
    }
}