using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : MonoBehaviour
{
    public GameObject gun;
    public GameObject mCamera;
    public GameObject target;
    public GameObject muzzlePoint;
    private LineRenderer lineR;
    public AudioSource fireSound;
    public GameObject npc;
    private Animator animator;
    

    private int hitCount;
    // Start is called before the first frame update
    void Start()
    {
        lineR = GetComponent<LineRenderer>();
        animator = npc.GetComponent<Animator>();
        hitCount = 0;        
    }

    IEnumerator ShowFlash(){
        lineR.SetPosition(0, muzzlePoint.transform.position);
        lineR.SetPosition(1, target.transform.position);

        fireSound.Play();
        yield return new WaitForSeconds(0.02f);
        lineR.SetPosition(0, transform.position);
        lineR.SetPosition(1, transform.position);
    }

    IEnumerator fallAndGetUp()
    {
        NavMeshAgent agent;
        agent = npc.GetComponent<NavMeshAgent>();
        animator.SetInteger("NinjaState", 2); 
        agent.enabled = false; // Stops movement
        yield return new WaitForSeconds(1);
        animator.SetInteger("NinjaState", 3);
        yield return new WaitForSeconds(1);
        agent.enabled = true; // Stops movement
        // animator.SetInteger("NinjaState", 0);
        animator.SetInteger("NinjaState", 1);
    }
    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space))&&(gun.active))
        {
            RaycastHit hit;
            if (Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit))
            {
                GameObject bulletClone = Instantiate(target, hit.transform.position , transform.rotation);
                bulletClone.transform.position = hit.point;
                StartCoroutine(ShowFlash());
                if(npc.transform.gameObject == hit.transform.gameObject)
                {
                    // animator.SetInteger("state", 2);
                    hitCount++;

                    if(hitCount<2)
                        StartCoroutine(fallAndGetUp());
                    else
                    {
                        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
                        agent.enabled = false; // Stops movement
                        animator.SetInteger("NinjaState", 2);
                    }
                }
                fireSound.Play();
            }
            else
            {
                fireSound.Play();
            }
        }

    }
}
