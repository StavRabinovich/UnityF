using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickGun : MonoBehaviour
{
    public GameObject FloorGun;
    public GameObject GunInHand;
    public GameObject mCamera;
    public Text gunText;

    private bool isShown, notTaken, textIsOpen;
    // Start is called before the first frame update
    void Start()
    {
/*        System.Random rand = new System.Random();
        isShown = rand.Next(0,2)>0;
        notTaken = true;
        textIsOpen = false;

        if (!isShown)
        {
            this.gameObject.SetActive(false); 
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit))
        {
            if (notTaken && !textIsOpen)
            {
                textIsOpen = true;
                gunText.text = "Press [E] to take gun.";
            }
            else if (!notTaken)
            {
                textIsOpen = false;
            }
            if (hit.transform.gameObject == FloorGun.gameObject) // The view is focused on GunInDrawer
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    notTaken = false;
                    FloorGun.gameObject.SetActive(false);
                    // FloorGun.gameObject.SetActive(false);
                    GunInHand.gameObject.SetActive(true);
                }
            }
        }
    }
}
