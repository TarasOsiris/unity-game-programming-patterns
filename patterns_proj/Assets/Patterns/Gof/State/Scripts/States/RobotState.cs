public abstract class RobotState 
{
    protected State2DRobotController _robot;

	protected RobotState(State2DRobotController robot)
    {
        _robot = robot;
    }

    public abstract RobotState HandleInput(State2DRobotInput.RobotInput input);
}
