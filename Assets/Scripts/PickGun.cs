using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickGun : MonoBehaviour
{
    //public GameObject FloorGun;
    public GameObject GunInHand;
    public GameObject mCamera;
    public TextMeshProUGUI txtGun;
    private bool notTaken;

    // Start is called before the first frame update
    void Start()
    {
        notTaken = true;
        //FloorGun.gameObject.SetActive(true);
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
        if ((notTaken) && (Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit)))
        {
            if (hit.transform.gameObject.tag == "FloorGun") // The view is focused on GunInDrawer
            {
                //txtGun.text = "Press [E] to TAKE the gun";
                if(Input.GetKeyDown(KeyCode.E))
                {
                    notTaken = false;
                    hit.transform.gameObject.gameObject.SetActive(false);
                    // FloorGun.gameObject.SetActive(false);
                    GunInHand.gameObject.SetActive(true);
                } 
            }
            /*else
            {
                txtGun.text = "No Gun";
            } */
        }
        
    }
}
