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
    private string otherTeam;
    private string myTeam;
    private int hitCount;
    public float bulletImpulse = 100f;
    public static bool mainCIsalive;
    public static bool EnemyOneIsAlive;
    // Start is called before the first frame update
    void Start()
    {
        lineR = GetComponent<LineRenderer>();
        animator = npc.GetComponent<Animator>();
        //hitCount = 0;
        this.myTeam = this.gameObject.tag;
        mainCIsalive = true;
        EnemyOneIsAlive = true;
    }

    IEnumerator ShowFlash(){
        lineR.SetPosition(0, muzzlePoint.transform.position);
        lineR.SetPosition(1, target.transform.position);

        fireSound.Play();
        yield return new WaitForSeconds(0.02f);
        lineR.SetPosition(0, transform.position);
        lineR.SetPosition(1, transform.position);
    }

 /*   IEnumerator fallAndGetUp()
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
    }*/
    public IEnumerator shootBullet(GameObject bulletClone)
    {
        yield return new WaitForSeconds(0.5f);
        bulletClone.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space))&&(gun.active))
        {
            RaycastHit hit;
            // If the object before me is not in my team, There will be a hit, else only sound
            if (Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hit) && !hit.transform.tag.Equals(this.myTeam))
            {
                GameObject bulletClone = Instantiate(this.target, hit.transform.position, transform.rotation);
                bulletClone.transform.position = hit.point;
                fireSound.Play();
                StartCoroutine(shootBullet(bulletClone));
                print(hit.ToString());
            }
            else
            {
                fireSound.Play();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if(other.gameObject.tag.Equals("Bullet") || other.gameObject.tag.Equals("granade"))
        {
            animator.SetInteger("state", 2);
            print("hit");
        }
    }

}
