using UnityEngine;

[RequireComponent(typeof(State2DRobotController))]
public class State2DRobotInput : MonoBehaviour 
{
    private State2DRobotController character;

    public class RobotInput
    {
        public float move;
        public bool crouch;
        public bool jump;
    }

    private RobotInput _robotInput;
    
    void Awake()
    {
        character = GetComponent<State2DRobotController>();
        _robotInput = new RobotInput() {move = 0.0f, crouch = false, jump = false};
    }
    
    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
        #if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) _robotInput.jump = true;
        #else
        if (Input.GetButtonDown("Jump")) _robotInput.jump = true;
        #endif
        
    }
    
    void FixedUpdate()
    {
        _robotInput.crouch = Input.GetKey(KeyCode.LeftControl);
        #if CROSS_PLATFORM_INPUT
        _robotInput.move = CrossPlatformInput.GetAxis("Horizontal");
        #else
        float h = Input.GetAxis("Horizontal");
        #endif
        
        // Pass all parameters to the character control script.
        character.UpdateState(_robotInput);
    }
}
