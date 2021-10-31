using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer1Motion : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHairSeeThrough;
    public GameObject crossHairTouch;
    public GameObject mCamera;
    public GameObject mGun;
    public Text drawerText;
    private bool drawerIsClosed, textIsOpen;


    // Start is called before the first frame update
    void Start()
    { 
        drawerIsClosed = true;
        textIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit))
        {
            if (hit.distance < 2 && hit.transform.gameObject == this.gameObject){
                if(drawerIsClosed && !textIsOpen)
                {
                    drawerText.text = "Press [R] to OPEN";
                    textIsOpen = true;
                }
                    
                else if(!drawerIsClosed && textIsOpen)
                {
                    drawerText.text = "Press [R] to CLOSE";
                    if(mGun.activeSelf)
                        drawerText.text += "\nPress [P] to PICK gun";
                    textIsOpen = false;
                }
                drawerText.gameObject.SetActive(true);
                crossHairSeeThrough.SetActive(false);
                crossHairTouch.SetActive(true);
                if(Input.GetKeyDown(KeyCode.R))
                {
                    animator.SetBool("drawer1Open", drawerIsClosed);
                    drawerIsClosed = !drawerIsClosed;
                }
            }
        }
        else
        {
            drawerText.gameObject.SetActive(false);
            crossHairSeeThrough.SetActive(true);
            crossHairTouch.SetActive(false);
        }
    }
}
