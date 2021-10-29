using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NinjaMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject player; // Ninjas target
    private LineRenderer aLine;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        aLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(player.transform.position); // Runs A* to find player
            aLine.positionCount = agent.path.corners.Length;
            for(int i=0; i< agent.path.corners.Length; i++)
            {
                aLine.SetPosition(i, agent.path.corners[i]);
            }
        }

        // if(Input.GetKeyDown(KeyCode.Z))
        // {
        //     animator.SetInteger("NinjaState", 0); // Goes to IDLE
        // }
        // else if(Input.GetKeyDown(KeyCode.X))
        // {
        //     animator.SetInteger("NinjaState", 1); // Goes to WALK
        // }
        // else if(Input.GetKeyDown(KeyCode.C))
        // {
        //     animator.SetInteger("NinjaState", 2); // Goes to DIE
        // }
        // else if(Input.GetKeyDown(KeyCode.V))
        // {
        //     animator.SetInteger("NinjaState", 3); // Goes to RISEUP
        // }
    }
}
