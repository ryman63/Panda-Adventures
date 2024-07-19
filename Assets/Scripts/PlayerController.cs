using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float KeyInputX, KeyInputZ;

    private bool _isGrounded;
    public bool IsShifting = false;

    float rotAngle = 0f;

    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float SpeedRotation = 1f;
    [SerializeField] public Vector3 InputVector;
    [SerializeField] private float JumpForce = 150f;
    [SerializeField] public FixedJoystick _fixedJoystick;

    void Start()
    {
        if (this.gameObject.name == "Sphere")
            IsShifting = true;
        PlayerBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        InputJoystick();

        InputVector = new Vector3(KeyInputX, 0f, KeyInputZ) * Speed;

        if (!IsShifting)
        {
            PlayerBody.velocity = new Vector3(InputVector.x, PlayerBody.velocity.y, InputVector.z);
        }
        else
        {
            PlayerBody.AddForce(new Vector3(InputVector.x, 0f, InputVector.z));
            
            transform.localRotation = Quaternion.Euler(rotAngle, 0f, 0f);
            rotAngle += 4f;
        }
            

        if (InputVector.magnitude > 0.05)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-InputVector), SpeedRotation);

        PlayerJump();

        PlayerShift();
    }

    void InputKeyButton()
    {
        KeyInputX = Input.GetAxis("Horizontal");
        KeyInputZ = Input.GetAxis("Vertical");
    }

    void InputJoystick()
    {
        KeyInputX = _fixedJoystick.Horizontal;
        KeyInputZ = _fixedJoystick.Vertical;
    }

    void PlayerJump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if(_isGrounded)
                PlayerBody.AddForce(Vector3.up * JumpForce);
        }
    }

    void PlayerShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!IsShifting)
            {
                Destroy(transform.gameObject.GetComponent<CapsuleCollider>());
                transform.gameObject.AddComponent<SphereCollider>();
                PlayerBody.rotation = Quaternion.Euler(PlayerBody.velocity.x, PlayerBody.velocity.y, PlayerBody.velocity.z);

                if (_isGrounded)
                {

                }
            }
            else
            {
                Destroy(transform.gameObject.GetComponent<SphereCollider>());
                transform.gameObject.AddComponent<CapsuleCollider>();
            }

            IsShifting = !IsShifting;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
    }

    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}