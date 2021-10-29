using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : MonoBehaviour
{
    public Animator animator;
    private NavMeshAgent agent;
    public GameObject takePlate; // 
    public GameObject npcPlate; //
    public GameObject takeSandwich; // 
    public GameObject npcSandwich; // 
    public GameObject cstFood;
    private LineRenderer aLine;
    private bool runAgain;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        aLine = GetComponent<LineRenderer>();
        runAgain = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Press G to start 
        if (agent.enabled && runAgain) 
        {
            runAgain = false;
            agent.SetDestination(takePlate.transform.position); // Runs A* to the plate
            aLine.positionCount = agent.path.corners.Length;
            for(int i=0; i< agent.path.corners.Length; i++)
            {
                aLine.SetPosition(i, agent.path.corners[i]);
            }
            
        }

    }
}
