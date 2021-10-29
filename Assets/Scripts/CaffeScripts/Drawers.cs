using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawers : MonoBehaviour
{
    public Animator upAnimator;
    public Animator dnAnimator;
    public GameObject chSeeThrough;
    public GameObject chTouch;
    public GameObject mCamera;
    public Text drawerText;
    private bool drawer1IsClosed, drawer2IsClosed, textIsOpen;

    // Start is called before the first frame update
    void Start()
    {
        drawer1IsClosed = true;
        drawer2IsClosed = true;
        textIsOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit))
        {
            
            if (hit.distance < 3 && hit.transform.gameObject == this.gameObject)
            {
                chSeeThrough.SetActive(false);
                chTouch.SetActive(true);
                drawerText.text = "HEY\t";

                if((!textIsOpen)&&(drawer1IsClosed))
                {
                    drawerText.text += "Press [E] to OPEN UPPER\n";
                    textIsOpen = true;
                }
                else if((textIsOpen)&&(!drawer1IsClosed))
                {
                    drawerText.text += "Press [E] to CLOSE UPPER\n";
                    textIsOpen = false;
                }
                if((!textIsOpen)&&(drawer2IsClosed))
                {
                    drawerText.text += "Press [R] to OPEN LOWER\n";
                    textIsOpen = true;
                }
                else if((textIsOpen)&&(!drawer2IsClosed))
                {
                    drawerText.text += "Press [R] to CLOSE LOWER\n";
                    textIsOpen = false;
                }
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    upAnimator.SetBool("isOpen", drawer1IsClosed);
                    drawer1IsClosed = !drawer1IsClosed;
                }
                if(Input.GetKeyDown(KeyCode.R))
                {
                    dnAnimator.SetBool("isOpen", drawer2IsClosed);
                    drawer2IsClosed = !drawer2IsClosed;
                }  
            }
            else
            {
                drawerText.gameObject.SetActive(false);
                chSeeThrough.SetActive(true);
                chTouch.SetActive(false);
            }
        }
    }
}
