using UnityEngine;

public class State2DRobotController : MonoBehaviour
{

    [SerializeField] LayerMask whatIsGround;

    // CONST
    private const float GROUNDED_RADIUS = 0.2f;

	// STATES
    private RobotState _robotState;

    // INPUT
    private bool _inputIsCrouchPressed;

    private Transform _groundCheck;
    private Animator _anim;

    private bool _isGrounded;

    void Awake()
    {
        _groundCheck = transform.Find("GroundCheck");
        _anim = GetComponent<Animator>();

        _robotState = new WalkState(this);
    }

    public void UpdateState(State2DRobotInput.RobotInput input)
    {
        var newState = _robotState.HandleInput(input);
        _robotState = newState;
    }

    void FixedUpdate()
    {
        UpdateRobotProperties();
    }

    void UpdateRobotProperties()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, GROUNDED_RADIUS, whatIsGround);
        _anim.SetBool("Ground", _isGrounded);
        _anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);    
    }
}
