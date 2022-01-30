using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera m_Camera;
    float m_Yaw;
    float m_Pitch;
    public Vector3 m_Forward;
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
    public KeyCode m_InteractKey = KeyCode.E;
    private bool m_CanControl;
    private bool m_OnGround;
    private float m_time;
    [Header("Gravity")]
    public float m_VerticalSpeed = 0.0f;
    public float m_GravityMultiplayer= 4;
    public bool m_Pause = false;

    private bool _pressed = false;
    public bool Pressed => _pressed;
    [Header("Objects")]
    public LayerMask m_LayerMask;
    public float m_distance = 20;
    public Transform ObjectPos;
    bool m_WachingObject = false;
    GameObject m_Object = null;
    float m_YawObject;
    float m_PitchObject;
    float m_timerOb = 0f;
    float m_TimerSoltar = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameController.GetGameController().SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Pause)
        {
            if (!m_WachingObject)
            {
                CameraMovement();
                Movement();
                InteractObject();
                if (!(m_TimerSoltar > 0)) 
                {
                    CheckObjects();
                }
                else
                {
                    m_TimerSoltar -= Time.deltaTime;
                }
                
            }
            else
            {
                UpdateObject();
            }
            
        }
       // _pressed = false;
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
        m_Forward = new Vector3(Mathf.Sin(l_YawInRadians), 0.0f, Mathf.Cos(l_YawInRadians));
        Vector3 l_Right = new Vector3(Mathf.Sin(l_Yaw90InRadians), 0.0f, Mathf.Cos(l_Yaw90InRadians));
        if (m_CanControl)
        {
            if (Input.GetKey(m_UpKeyCode))
                l_Movement += m_Forward;
            else if (Input.GetKey(m_DownKeyCode))
                l_Movement = -m_Forward;
            if (Input.GetKey(m_RightKeyCode))
                l_Movement += l_Right;
            else if (Input.GetKey(m_LeftKeyCode))
                l_Movement -= l_Right;
            l_Movement.Normalize();
        }

        l_Movement = l_Movement * Time.deltaTime * m_Speed;
        m_VerticalSpeed += Physics.gravity.y * Time.deltaTime * m_GravityMultiplayer;
        l_Movement.y = m_VerticalSpeed * Time.deltaTime;



        CollisionFlags l_CollisionFlags = m_CharacterController.Move(l_Movement);//Macara binaria para saber como hemos chocado, por arriba abajo
        if ((l_CollisionFlags & CollisionFlags.Below) != 0)//Colisiona con el suelo
        {
            m_VerticalSpeed = 0; 
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

    private void InteractObject()
    {
       if(Input.GetKey(m_InteractKey))
       {
            _pressed = true;

        }
        else
        {
            _pressed = false;
        }
    }

    public void CheckObjects()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position + m_CharacterController.center;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, m_CharacterController.height / 2, m_Camera.transform.forward, out hit, m_distance, m_LayerMask))
        {
            hit.transform.GetComponent<IterfaceInteractable>()?.AppealInteractuable();
            if (Input.GetKey(m_InteractKey))
            {
                hit.transform.GetComponent<IterfaceInteractable>()?.Interact();
            }
        }
    }
    public void StartObservingObject(GameObject gameObject)
    {
        m_Object = Instantiate(gameObject, null);
        
        m_Object.transform.position = transform.TransformPoint(ObjectPos.transform.position);
        m_Object.transform.position = (ObjectPos.transform.position);
        m_WachingObject = true;
        
    }
    public void UpdateObject()
    {
        //ROTACION CAMARA input
        float l_MouseAxisY = Input.GetAxis("Mouse Y");
        float l_MouseAxisX = Input.GetAxis("Mouse X");
        //m_pitch es x en mru x = x0+v*t
         m_PitchObject += l_MouseAxisY * m_PitchRotationalSpeed * Time.deltaTime * (m_InvertedPitch ? -1.0f : 1.0f);
        m_PitchObject = Mathf.Clamp(m_PitchObject, m_MinPitch, m_MaxPitch);

        m_YawObject += l_MouseAxisX * m_YawRotationalSpeed * Time.deltaTime * (m_InvertedYaw ? -1.0f : 1.0f);

        m_Object.transform.rotation = Quaternion.Euler(m_PitchObject, m_YawObject, 0);
        m_Object.transform.rotation = Quaternion.Euler(m_PitchObject, m_YawObject, m_Object.transform.localRotation.eulerAngles.z);

        m_timerOb += Time.deltaTime;
        if (m_timerOb > 1f)
        {
            if (Input.GetKey(m_InteractKey))
            {
                m_WachingObject = false;
                Destroy(m_Object);
                m_timerOb = 0;
                m_TimerSoltar = 1f;
            }
        }
        
    }
}

