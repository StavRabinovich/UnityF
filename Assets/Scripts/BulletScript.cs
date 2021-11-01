using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (other.gameObject.tag.Equals("Red Team"))
        {
            //animator.SetInteger("state", 2);
            print("hit");
        }
        print(other.gameObject.tag);
    }
}
