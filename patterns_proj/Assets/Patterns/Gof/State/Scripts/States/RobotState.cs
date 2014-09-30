using UnityEngine;
using System.Collections;

public abstract class RobotState 
{
    protected State2DRobotController _robot;

    public RobotState(State2DRobotController robot)
    {
        _robot = robot;
    }

    public abstract RobotState UpdateRobot(State2DRobotInput.RobotInput input);
}
