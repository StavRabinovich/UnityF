using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwGrenade : MonoBehaviour
{
    public GameObject grenade;
    public GameObject explodsion;
    SphereCollider s_collider;
    float s_radious;
    // Start is called before the first frame update
    void Start()
    {
        s_collider = GetComponent<SphereCollider>();
        s_radious = 2;
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
            StartCoroutine(Explode());
            StartCoroutine(disableGrenade());
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1);
        AudioSource sound = grenade.GetComponent<AudioSource>();
        sound.Play();
        explodsion.transform.position = grenade.transform.position;
        grenade.tag = "granade";
        s_collider.radius = s_radious;
        explodsion.SetActive(true);
    }

    IEnumerator disableGrenade()
    {
        yield return new WaitForSeconds(3);
        grenade.SetActive(false);
    }
}
