using UnityEngine;

public class WalkState : RobotState
{
    private const float MAX_SPEED = 10f;
    protected Animator _robotAnimator;

    bool _facingRight = true;  

    public WalkState(State2DRobotController robot) : base(robot)
    {
        _robotAnimator = robot.gameObject.GetComponent<Animator>();
    }

    public override RobotState UpdateRobot(State2DRobotInput.RobotInput input)
    {
        _robotAnimator.SetBool("Crouch", input.crouch);
        
        _robotAnimator.SetFloat("Speed", Mathf.Abs(input.move));
        _robot.rigidbody2D.velocity = new Vector2(input.move * MAX_SPEED, _robot.rigidbody2D.velocity.y);       

        if (input.move > 0 && !_facingRight) { Flip(); }
        else if(input.move < 0 && _facingRight) { Flip(); }

        if (input.crouch) { return new CrouchState(_robot); }
        return this;
    }

    void Flip ()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = _robot.transform.localScale;
        theScale.x *= -1;
        _robot.transform.localScale = theScale;
    }
}
