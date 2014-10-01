using UnityEngine;
using System.Collections;

public class CrouchState : WalkState
{
    private const float CROUCH_SPEED = 0.36f;

    public CrouchState(State2DRobotController robot) : base(robot) {}

    public override RobotState HandleInput(State2DRobotInput.RobotInput input)
    {
        if (!input.crouch) { return new WalkState(_robot); }
         
        input.move = (input.move * CROUCH_SPEED);
        base.HandleInput(input);
        return this;
    }
}
