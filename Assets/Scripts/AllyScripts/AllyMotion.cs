using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class AllyMotion : MonoBehaviour
{

    // Start is called before the first frame update
    public Animator animator;
    private string myTeam;
    private int hitCount;
    private bool canGetHit = true;
    public bool isAlive;
    public GameObject endScreen;

    public TextMeshProUGUI txtVictory;
    //NavMeshAgent who to follow
    private NavMeshAgent agent;
    public GameObject player;
    // Movement
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    public float minDistanceSqr;
    //Gun
    public GameObject AllyGun;
    public bool isHoldingGun;
    //Path
    private LineRenderer line;
    //End Game
    void Start()
    {
        endScreen = GameObject.Find("EndGame");
        animator = GetComponent<Animator>();
        this.myTeam = this.gameObject.tag;
        this.hitCount = 2;
        isAlive = true;
        agent = GetComponent<NavMeshAgent>();  //agent
        lastPosition = transform.position;
        minDistanceSqr = 5;
        isHoldingGun = false;
        line = GetComponent<LineRenderer>(); //line
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        var destPosition = player.transform.position;
        var sqrDistance = (transform.position - destPosition).sqrMagnitude;
        //Draw path
        line.positionCount = agent.path.corners.Length;
        for (int i = 0; i < agent.path.corners.Length; i++)
            line.SetPosition(i, agent.path.corners[i]);
        print("Corners = " + agent.path.corners.Length);
        // Movment
        if (isAlive && sqrDistance > minDistanceSqr)
        {
            agent.SetDestination(destPosition); // Set destination to plyaer A* algorith to find path to target
            if (currentPosition.x - lastPosition.x != 0 || currentPosition.y - lastPosition.y != 0)
                animator.SetInteger("state", 1);
        }
        else
        {
            agent.SetDestination(currentPosition);
            animator.SetInteger("state", 0);
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
        if (other.gameObject.tag.Equals("FloorGun"))
        {
            AllyGun.SetActive(true);
            isHoldingGun = true;
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator getHit()
    {
        if (hitCount > 0)
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetInteger("state", 0);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetInteger("state", 3);
            isAlive = false;
            print("dead");
            txtVictory.text = "Red Victory!";
            //finishPnl.SetActive(true);
            //endScript.enemyAlive = false;
            //finishPnl.GetComponent<QuitGame>().enemyAlive = false;
            //endScreen.GameObject.SetActive(true);
            //finishPnl.GetComponent<QuitGame>().enemyAlive = false;
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
