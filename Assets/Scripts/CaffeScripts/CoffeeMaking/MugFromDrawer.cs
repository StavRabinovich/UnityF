using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugFromDrawer : MonoBehaviour
{
    public GameObject MugInDrawer;
    public GameObject MugInHand;
    public GameObject mCamera;

    private bool showMug;
    // Start is called before the first frame update
    void Start()
    {
        showMug = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit))
        {
            if (hit.transform.gameObject == MugInDrawer.gameObject) // The view is focused on GunInDrawer
            {
                if(Input.GetKeyDown(KeyCode.M))
                {
                    showMug = !showMug;
                    MugInHand.gameObject.SetActive(showMug);
                }
            }
        }
    }
}
