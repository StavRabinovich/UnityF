using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed, angularSpeed;
    private CharacterController controller;
    private float rotaionAboutX, rotaionAboutY;
    [SerializeField]
    public GameObject playerCamera;
    private AudioSource stepSound;
    private Animator animator;
    void Start()
    {
        speed = 3;
        angularSpeed = 200;
        controller = GetComponent<CharacterController>();
        rotaionAboutY = transform.rotation.y;
        stepSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dy = -1, dz; // dy = -1 is gravity
        // Can be one of -1,0,1
        //Player Rotaion
        rotaionAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotaionAboutY, 0);
        // Camera Rotaion
        rotaionAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        playerCamera.transform.localEulerAngles = new Vector3(rotaionAboutX, 0, 0);
        
        // KeyboardRotaion
        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // right/left
        dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;  //Forward/Backwords
        
        // Motion using character controller
        Vector3 motion = new Vector3(dx, dy, dz); //Motion is defined in Local Coordinates
        motion = transform.TransformDirection(motion); //Now motion is in Global coordiantes
        controller.Move(motion); //must receive Vector3 in Global coordinates
        // Motion sound
        if (dz < -0.03 || dz > 0.03 || dx < -0.03 || dx > 0.03)
        {
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
            animator.SetInteger("state", 1); //walking state
        }
        else
        {
            animator.SetInteger("state", 0); //Idle stat
        }

    }
}
