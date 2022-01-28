using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera m_Camera;
    float m_Yaw;
    float m_Pitch;
    [Header("Camera")]
    public float m_YawRotationalSpeed = 360.0f;
    public float m_PitchRotationalSpeed = 180.0f;
    public float m_MinPitch = -80.0f;
    public float m_MaxPitch = 50.0f;
    public Transform m_PitchControllerTransform;
    public bool m_InvertedYaw = false;
    public bool m_InvertedPitch = true;

    [Header("Controls")]
    public CharacterController m_CharacterController;
    public float m_Speed = 10.0f;
    public KeyCode m_LeftKeyCode = KeyCode.A;
    public KeyCode m_RightKeyCode = KeyCode.D;
    public KeyCode m_UpKeyCode = KeyCode.W;
    public KeyCode m_DownKeyCode = KeyCode.S;
    public KeyCode m_ReloadCode = KeyCode.R;
    private bool m_CanControl;
    private bool m_OnGround;
    private float m_time;
    [Header("Gravity")]
    public float m_VerticalSpeed = 0.0f;
    public float m_GravityMultiplayer= 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        Movement();
    }

    private void CameraMovement()
    {
        //ROTACION CAMARA input
        float l_MouseAxisY = Input.GetAxis("Mouse Y");
        float l_MouseAxisX = Input.GetAxis("Mouse X");
        //m_pitch es x en mru x = x0+v*t
        m_Pitch += l_MouseAxisY * m_PitchRotationalSpeed * Time.deltaTime * (m_InvertedPitch ? -1.0f : 1.0f);
        m_Pitch = Mathf.Clamp(m_Pitch, m_MinPitch, m_MaxPitch);

        m_Yaw += l_MouseAxisX * m_YawRotationalSpeed * Time.deltaTime * (m_InvertedYaw ? -1.0f : 1.0f);

        transform.rotation = Quaternion.Euler(0.0f, m_Yaw, 0);
        m_PitchControllerTransform.localRotation = Quaternion.Euler(m_Pitch, 0.0f, m_PitchControllerTransform.localRotation.eulerAngles.z);

    }

    private void Movement()
    {

        Vector3 l_Movement = Vector3.zero;
        float l_YawInRadians = m_Yaw * Mathf.Deg2Rad;
        float l_Yaw90InRadians = (m_Yaw + 90.0f) * Mathf.Deg2Rad;
        Vector3 l_Forward = new Vector3(Mathf.Sin(l_YawInRadians), 0.0f, Mathf.Cos(l_YawInRadians));
        Vector3 l_Right = new Vector3(Mathf.Sin(l_Yaw90InRadians), 0.0f, Mathf.Cos(l_Yaw90InRadians));
        if (m_CanControl)
        {
            if (Input.GetKey(m_UpKeyCode))
                l_Movement += l_Forward;
            else if (Input.GetKey(m_DownKeyCode))
                l_Movement = -l_Forward;
            if (Input.GetKey(m_RightKeyCode))
                l_Movement += l_Right;
            else if (Input.GetKey(m_LeftKeyCode))
                l_Movement -= l_Right;
            l_Movement.Normalize();
        }

        //Apply momentum
        //l_Movement += m_CharacterVelocityMomemtum;
        l_Movement = l_Movement * Time.deltaTime * m_Speed;
        m_VerticalSpeed += Physics.gravity.y * Time.deltaTime * m_GravityMultiplayer;
        l_Movement.y = m_VerticalSpeed * Time.deltaTime;



        CollisionFlags l_CollisionFlags = m_CharacterController.Move(l_Movement);//Macara binaria para saber como hemos chocado, por arriba abajo
        if ((l_CollisionFlags & CollisionFlags.Below) != 0)//Colisiona con el suelo
        {
            m_OnGround = true;
            m_time = Time.time;
            m_CanControl = true;
        }
        else
        {
            if (Time.time - m_time > 0.3)
            {
                m_OnGround = false;
            }
        }

    }


}