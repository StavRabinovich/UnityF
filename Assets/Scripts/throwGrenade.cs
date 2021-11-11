using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwGrenade : MonoBehaviour
{
    public GameObject grenade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            float x, y, z;
            x = transform.forward.x * 10;
            y = 5;
            z = transform.forward.z * 10;

            Rigidbody rb = grenade.GetComponent<Rigidbody>(); // Assumption grenade as RGC
            rb.AddForce(x, y, z, ForceMode.Impulse);
            rb.useGravity = true;
        }
    }
}
