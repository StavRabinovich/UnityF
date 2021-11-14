using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class N2 : MonoBehaviour
{
    public Animator animator;
    private string myTeam;
    private int hitCount;
    private bool canGetHit = true;
    public bool isAlive;
    public GameObject endScreen;
    /*public QuitGame endScript;
    public GameObject finishPnl;*/
    public TextMeshProUGUI txtVictory;
    //path
    private LineRenderer line; //path
    private NavMeshAgent agent;
    public GameObject player;
    //Gun
    private bool isHoldingGun;
    public GameObject N2Gun;
    //Shooting
    public GameObject target;
    public AudioSource fireSound;
    private Vector3 myPos;
    private bool canShoot;
    // Movement
    private Vector3 currentPosition;
    private Vector3 lastPosition;
    public GameObject leader;
    // Start is called before the first frame update
    void Start()
    {
        endScreen = GameObject.Find("EndGame");
        animator = GetComponent<Animator>();
        this.myTeam = this.gameObject.tag;
        this.hitCount = 2;
        isAlive = true;
        line = GetComponent<LineRenderer>(); //line
        agent = GetComponent<NavMeshAgent>();  //agent
        isHoldingGun = false;
        myPos = gameObject.transform.position;
        canShoot = true;
        lastPosition = transform.position;
    }
    //shooting the player
    public IEnumerator shoot()
    {
        if (isHoldingGun)
        {
            animator.SetInteger("state", 1);
            yield return new WaitForSeconds(1f);
            targetPlayer(); // Target the player
            yield return new WaitForSeconds(1f);
            shooting();
            yield return new WaitForSeconds(1f);
            canShoot = false;
        }
    }
    void shooting()
    {
        RaycastHit hit;
        // If the object before me is not in my team, There will be a hit, else only sound
        if (Physics.Raycast(gameObject.transform.position, player.transform.forward))
        {
            player.gameObject.GetComponent<PlayerMotion>().TakeDamage();
            fireSound.Play();
        }
    }
    public IEnumerator shootBullet(GameObject bulletClone)
    {
        yield return new WaitForSeconds(2f);
        bulletClone.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (other.gameObject.tag.Equals("Bullet") && canGetHit)
        {
            canGetHit = false;
            animator.SetInteger("state", 2);
            print("hit");
            StartCoroutine(getHit());
            hitCount = hitCount - 1;
            canGetHit = true;
        }
        else if (other.gameObject.tag.Equals("FloorGun"))
        {
            N2Gun.SetActive(true);
            isHoldingGun = true;
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator getHit()
    {
        if (hitCount > 0)
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetInteger("state", 2);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetInteger("state", 3);
            isAlive = false;
            print("dead");
            txtVictory.text = "Blue Victory!";
            //finishPnl.GetComponent<QuitGame>().enemyAlive = false;
            //GameObject.Find("pnlBlue").GetComponent<blueBoard>().De
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("state", 1);
        currentPosition = gameObject.transform.position;
        var destPosition = player.transform.position;
        if (isAlive)
        {
            if (isHoldingGun)
            {
                agent.SetDestination(destPosition);
                var sqrDistance = (currentPosition - destPosition).sqrMagnitude;
                //draw path
                line.positionCount = agent.path.corners.Length;
                for (int i = 0; i < agent.path.corners.Length; i++)
                    line.SetPosition(i, agent.path.corners[i]);
                if (isHoldingGun && canShoot && agent.path.corners.Length < 3 && sqrDistance < 20)
                {
                    canShoot = false;
                    StartCoroutine(shoot());
                }

            }
            else
            {
                agent.SetDestination(leader.transform.position);
            }
            lastPosition = gameObject.transform.position;
        }
    }
    void targetPlayer()
    {
        Vector3 PlayerPos = player.transform.position;
        Vector3 delta = new Vector3(PlayerPos.x - myPos.x, myPos.y, PlayerPos.z - myPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = rotation;
        gameObject.transform.position = myPos;
        myPos = gameObject.transform.position;
    }
}
