using UnityEngine;
using System.Collections;

public abstract class RobotState 
{
    protected State2DRobotController _robot;

    public RobotState(State2DRobotController robot)
    {
        _robot = robot;
    }

    public abstract RobotState HandleInput(State2DRobotInput.RobotInput input);
}
