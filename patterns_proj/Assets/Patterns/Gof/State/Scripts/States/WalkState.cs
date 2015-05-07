using UnityEngine;

public class WalkState : RobotState
{
    private const float MAX_SPEED = 10f;
	private readonly Animator _robotAnimator;

    bool _facingRight = true;  

    public WalkState(State2DRobotController robot) : base(robot)
    {
        _robotAnimator = robot.gameObject.GetComponent<Animator>();
    }

    public override RobotState HandleInput(State2DRobotInput.RobotInput input)
    {
        _robotAnimator.SetBool("Crouch", input.crouch);
        
        _robotAnimator.SetFloat("Speed", Mathf.Abs(input.move));
        _robot.GetComponent<Rigidbody2D>().velocity = new Vector2(input.move * MAX_SPEED, _robot.GetComponent<Rigidbody2D>().velocity.y);       

        FlipIfRequired(input);

        if (input.crouch) { return new CrouchState(_robot); }
        return this;
    }

	private void FlipIfRequired(State2DRobotInput.RobotInput input) 
	{
		if (input.move > 0 && !_facingRight) {
			Flip();
		} else if (input.move < 0 && _facingRight) {
			Flip();
		}
	}

	void Flip ()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = _robot.transform.localScale;
        theScale.x *= -1;
        _robot.transform.localScale = theScale;
    }
}
