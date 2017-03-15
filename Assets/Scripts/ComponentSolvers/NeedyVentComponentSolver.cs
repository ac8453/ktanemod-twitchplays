﻿using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class NeedyVentComponentSolver : ComponentSolver
{
    public NeedyVentComponentSolver(MonoBehaviour bomb, MonoBehaviour bombComponent) :
        base(bomb, bombComponent)
    {
        _yesButton = (MonoBehaviour)_yesButtonField.GetValue(bombComponent);
        _noButton = (MonoBehaviour)_noButtonField.GetValue(bombComponent);
    }

    protected override IEnumerator RespondToCommandInternal(string inputCommand)
    {
        if (inputCommand.Equals("y", StringComparison.InvariantCultureIgnoreCase))
        {
            yield return "yes";

            DoInteractionStart(_yesButton);
            yield return new WaitForSeconds(0.1f);
            DoInteractionEnd(_yesButton);
        }
        else if (inputCommand.Equals("n", StringComparison.InvariantCultureIgnoreCase))
        {
            yield return "no";

            DoInteractionStart(_noButton);
            yield return new WaitForSeconds(0.1f);
            DoInteractionEnd(_noButton);
        }
    }

    static NeedyVentComponentSolver()
    {
        _needyVentComponentSolverType = ReflectionHelper.FindType("NeedyVentComponent");
        _yesButtonField = _needyVentComponentSolverType.GetField("YesButton", BindingFlags.Public | BindingFlags.Instance);
        _noButtonField = _needyVentComponentSolverType.GetField("NoButton", BindingFlags.Public | BindingFlags.Instance);
    }

    private static Type _needyVentComponentSolverType = null;
    private static FieldInfo _yesButtonField = null;
    private static FieldInfo _noButtonField = null;

    private MonoBehaviour _yesButton = null;
    private MonoBehaviour _noButton = null;
}