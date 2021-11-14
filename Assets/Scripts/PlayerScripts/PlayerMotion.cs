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
    //Taking damage
    private int life = 4;
    private bool isAlive;
    //End game
    public GameObject finishPnl;
    void Start()
    {
        speed = 4;
        angularSpeed = 200;
        controller = GetComponent<CharacterController>();
        rotaionAboutY = transform.rotation.y;
        stepSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        isAlive = true;
        //End Game
        //finishPnl = GameObject.Find("EndGame");
        //finishPnl.SetActive(true);
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
        if (!checklife())
        {
            finishPnl.SetActive(true);
        }

    }
    public void TakeDamage()
    {
        life = life - 1;
        print("life = " + life);
        if(life < 0 )
        {
            animator.SetInteger("state", 3); // Dead state  
            isAlive = false;
        }
        else
        {
            animator.SetInteger("state", 2); // Damage state
        }
    }
    private bool checklife()
    {
        GameObject N1 = GameObject.Find("N1");
        GameObject N2 = GameObject.Find("N2");
        if (N1.GetComponent<N1>().isAlive || N2.GetComponent<N2>().isAlive) // If one of them alive
            return true;
        return false; // If both dead
    }
}
