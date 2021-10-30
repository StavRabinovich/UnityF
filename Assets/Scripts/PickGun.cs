using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject FloorGun;
    public GameObject GunInHand;
    public GameObject mCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit))
        {
            if (hit.transform.gameObject == FloorGun.gameObject) // The view is focused on GunInDrawer
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    FloorGun.gameObject.SetActive(false);
                    FloorGun.gameObject.SetActive(false);
                    GunInHand.gameObject.SetActive(true);
                }
            }
        }
    }
}
