using UnityEngine;
using System.Collections;

public class State2DRobotController : MonoBehaviour
{

    [SerializeField] LayerMask whatIsGround;

    // CONST
    private const float GROUNDED_RADIUS = 0.2f;

    private RobotState _robotState;

    // INPUT
    private bool _inputIsCrouchPressed;

    private Transform _groundCheck;
    private Animator _anim;

    private bool _isGrounded = false;

    void Awake()
    {
        _groundCheck = transform.Find("GroundCheck");
        _anim = GetComponent<Animator>();

        _robotState = new WalkState();
    }

    public void UpdateState(float move, bool crouch, bool jump)
    {
//        _robotState.UpdateRobot(this);
        
    }

    void FixedUpdate()
    {
        UpdateRobotProperties();
    }

    void UpdateRobotProperties()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, GROUNDED_RADIUS, whatIsGround);
        _anim.SetBool("Ground", _isGrounded);
        _anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
    }

    void UpdateInput()
    {

    }
}
