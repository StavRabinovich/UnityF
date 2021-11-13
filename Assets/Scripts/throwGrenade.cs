using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class throwGrenade : MonoBehaviour
{
    public GameObject grenade;
    public GameObject handGrenade;
    public GameObject explodsion;
    SphereCollider s_collider;
    private bool notTaken;
    public TextMeshProUGUI txtGrenade;

    float s_radious;
    // Start is called before the first frame update
    void Start()
    {
        s_collider = GetComponent<SphereCollider>();
        s_radious = 2;
        notTaken = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit))
        {
            if (hit.transform.gameObject.tag == "FloorGrenade") // The view is focused on GunInDrawer
            {
                if (notTaken)
                {
                    txtGrenade.text = "Press [T] to TAKE grenade";
                    if(Input.GetKeyDown(KeyCode.T)) // Take Grenade
                    {
                        notTaken = false;
                        hit.transform.gameObject.gameObject.SetActive(false);
                        grenade.gameObject.SetActive(false);
                        handGrenade.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                txtGrenade.text = "No Grenades";
            }
        }

        if (handGrenade.active)
        {
            txtGrenade.text = "Press [G] to shoot grenade";

            if (Input.GetKeyDown(KeyCode.G)) // Throws grenade
            {
                GameObject dpGrenade = Instantiate(handGrenade, handGrenade.transform.position, transform.rotation);
                float x, y, z;
                x = transform.forward.x * 10;
                y = 5;
                z = transform.forward.z * 10;
                Rigidbody rb = handGrenade.GetComponent<Rigidbody>(); // Assumption grenade as RGC
                rb.AddForce(x, y, z, ForceMode.Impulse);
                rb.useGravity = true;
                StartCoroutine(Explode(dpGrenade));
                StartCoroutine(disableGrenade(dpGrenade));
            }
        }
    }

    IEnumerator Explode(GameObject grnd)
    {
        yield return new WaitForSeconds(1);
        AudioSource sound = grnd.GetComponent<AudioSource>();
        sound.Play();
        explodsion.transform.position = grnd.transform.position;
        grnd.tag = "granade";
        s_collider.radius = s_radious;
        explodsion.SetActive(true);
    }

    IEnumerator disableGrenade(GameObject grnd)
    {
        yield return new WaitForSeconds(3);
        grnd.SetActive(false);
    }
}
