using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    CharacterController PlayerController;
    
    public float PlayerWalkSpeed = 5;
    public float PlayerRunSpeed = 7;
    public float CrouchWalkSpeed = 2;
    public GameObject PlayerCamera;
    public GameObject CameraHolder;
    Vector3 Velocity;
    [HideInInspector] public CurrentState PlayerState;
    public bool isCrouch;
    public float CrouchHeight = 0.4f;

    float StartCameraPos;
    public float CrouchCameraHeight = 0.1f;


    public int stickCount = 0;

    public Text TextStickCount;

    public enum CurrentState
    {
        Idle = 0,
        Walk,
        Run,
        Crouch,
        CrouchWalk
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
        StartCameraPos = PlayerCamera.transform.localPosition.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float xAxies = Input.GetAxis("Horizontal");
        float zAxies = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xAxies + transform.forward * zAxies;

        if (isCrouch)
        {
            PlayerController.Move(move * CrouchWalkSpeed * Time.deltaTime);
        }
        else 
        {
            PlayerController.Move(move * PlayerWalkSpeed * Time.deltaTime);
        }
    
        if(PlayerController.velocity.magnitude == 0)
        {
            if (!isCrouch)
            { 
                PlayerState = CurrentState.Idle;
            }
            else 
            {
                PlayerState = CurrentState.Crouch;
            }
        }
        else
        {
            if (!isCrouch)
            {
                PlayerState = CurrentState.Walk;
            }
            else
            {
                PlayerState = CurrentState.CrouchWalk;
            }
        }
        //Debug.Log(PlayerState);

        if (!PlayerController.isGrounded)
        {
            Velocity = Physics.gravity + Physics.gravity;
            PlayerController.Move(Physics.gravity * Time.deltaTime);
        }   
    }

    

    private void Update()
    {

        TextStickCount.text = stickCount.ToString();


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isCrouch)
            {
                if (!Physics.Raycast(PlayerCamera.transform.position, Vector3.up, 1f))
                {
                    PlayerCamera.transform.localPosition = new Vector3(0, StartCameraPos, 0);
                        
                    PlayerController.height = 1.88f;
                    isCrouch = false;
                    PlayerState = CurrentState.Idle;
                    PlayerController.Move(Vector3.up * Time.deltaTime * 10);
                    //Debug.LogError("Now Not Crouch");
                }
            }
            else
            {

                PlayerCamera.transform.localPosition = new Vector3(0, CrouchCameraHeight, 0);
                PlayerController.height = CrouchHeight;
                isCrouch = true;
                PlayerState = CurrentState.Crouch;
                //Debug.LogError("Now Crouch");
            }
        }
    }
}
