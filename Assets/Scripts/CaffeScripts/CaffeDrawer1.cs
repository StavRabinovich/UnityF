using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaffeDrawer1 : MonoBehaviour
{
    public Animator animator;
    public GameObject chSeeThrough;
    public GameObject chTouch;
    public GameObject mCamera;
    public Text drawerText;
    private bool drawerIsClosed, textIsOpen;

    // Start is called before the first frame update
    void Start()
    {
        drawerIsClosed = true;
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
                
                if (drawerIsClosed && !textIsOpen)
                {
                    drawerText.text = "Press [E] to OPEN UPPER\n";
                    textIsOpen = true;
                }
                else if (!drawerIsClosed && textIsOpen)
                {
                    drawerText.text = "Press [E] to CLOSE UPPER\n";
                    textIsOpen = false;
                }
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("isOpen", drawerIsClosed);
                    drawerIsClosed = !drawerIsClosed;
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
